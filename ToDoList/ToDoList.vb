Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class ToDoList
    Dim _TAREA As String ' Variable para almacenar las tareas
    Dim _FECHA As String ' Variable para almacenar la fecha
    Dim _ESTADO As String ' Variable para almacenar el estado

    ' Funcion que nos permite hacer la lectura y envio del texto de la tarea
    Private Property TAREA As String
        Get
            Return _TAREA
        End Get
        Set(value As String)
            _TAREA = value
        End Set
    End Property

    ' Funcion que nos permite hacer la lectura y envio del texto de la fecha
    Private Property FECHA As String
        Get
            Return _FECHA
        End Get
        Set(value As String)
            _FECHA = value
        End Set
    End Property

    ' Funcion que nos permite hacer la lectura y envio del texto del estado
    Private Property ESTADO As String
        Get
            Return _ESTADO
        End Get
        Set(value As String)
            _ESTADO = value
        End Set
    End Property

    Private Sub ToDoList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReadTXT()

        ' Configura el valor predeterminado seleccionado
        cboEstado.SelectedIndex = 0
    End Sub

    Private Sub ReadTXT()
        Clear()
        ' Limpiar los DataGridView
        dgvCompletadas.Rows.Clear()
        dgvPendientes.Rows.Clear()

        ' Lee el archivo de texto y procesa las tareas
        Using sr As New StreamReader("TAREAS.txt")
            Dim linea As String
            While Not sr.EndOfStream
                linea = sr.ReadLine()
                ' Dividir la línea en elementos usando la coma como delimitador
                Dim elementos As String() = linea.Split(","c)

                ' Verificar si la tarea está pendiente o completada
                If elementos.Length = 3 AndAlso elementos(2).Trim().Equals("Pendiente") Then
                    ' Si la tarea está pendiente, agrégala a dgvPendientes
                    dgvPendientes.Rows.Add(elementos)
                ElseIf elementos.Length = 3 AndAlso elementos(2).Trim().Equals("Completa") Then
                    ' Si la tarea está completada, agrégala a dgvCompletadas
                    dgvCompletadas.Rows.Add(elementos)
                End If
            End While
        End Using
    End Sub

    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        If cboEstado.Text = "--SELECCIONAR--" Then
            MsgBox("Tienes que establecer un valor para el estado que sea diferente a seleccionar", MessageBoxIcon.Error)
        Else
            ' Esta linea nos permite concatenar el textbox, la fecha y el combobox para guardarlos en una nueva linea en nuestro archivo de texto
            File.AppendAllText("TAREAS.txt", Environment.NewLine + (txtTarea.Text & "," & dtpFecha.Text & "," & cboEstado.Text))

            ReadTXT()
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Clear()
    End Sub

    Private Sub Clear()
        txtTarea.Text = ""
        cboEstado.Text = "--SELECCIONAR--"
        btnActualizar.Enabled = False
        txtTarea.Focus()
        btnIngresar.Enabled = True
        EliminaLineaVacia()
    End Sub

    Private Sub EliminaLineaVacia()
        ' esta funcion nos permite eliminar las lineas vacias que tenga nuestro archivo para que en datagridview no se muestren y no nos de error
        Dim strFile As String = File.ReadAllText("TAREAS.txt")
        strFile = Regex.Replace(strFile, "^\r|\n\r|\n$", "")
        File.WriteAllText("TAREAS.txt", strFile)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If MessageBox.Show("¿Está seguro que desea salir?", "Confirmar Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ' Cierra la aplicación
            Application.Exit()
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If MessageBox.Show("¿Está seguro que desea eliminar esta tarea?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Try
                FilterFile("TAREAS.txt", txtTarea.Text)
                MsgBox("Tarea eliminada correctamente")
                ReadTXT()
            Catch ex As Exception
                MsgBox("Se produjo un error al intentar eliminar la tarea: " & ex.Message, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Function FilterFile(ByVal sFile As String, ByVal sFilter As String) As Boolean
        'Funcion para buscar coincidencias en nuestro archivo de texto para eliminarlos

        Dim lines As New List(Of String)
        Try

            Using sr As New StreamReader(sFile)
                While Not sr.EndOfStream
                    lines.Add(sr.ReadLine)
                End While
            End Using
            For i As Integer = lines.Count - 1 To 0 Step -1
                If lines(i).Contains(sFilter) Then lines.Remove(lines.Item(i))
            Next

            Using sw As New StreamWriter(sFile)
                For Each line As String In lines
                    sw.WriteLine(line)
                Next
            End Using
            Return True
        Catch ex As Exception : Return False : End Try
    End Function

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If cboEstado.Text = "--SELECCIONAR--" Then
            MsgBox("Tienes que establecer un valor para el estado que sea diferente a seleccionar", MessageBoxIcon.Error)
        Else
            Update()
        End If
    End Sub

    Private Overloads Sub Update()
        Dim jumbofile As String = "TAREAS.txt" ' variable para cargar nuestro archivo de texto
        Dim newline As String = (txtTarea.Text & "," & dtpFecha.Text & "," & cboEstado.Text)

        If System.IO.File.Exists(jumbofile) Then ' si la linea o los datos que deseamos cambiar existe, entonces realizamos el cambio
            Dim lines() As String = IO.File.ReadAllLines(jumbofile)
            For i As Integer = 0 To lines.Length - 1
                If lines(i).Contains(TAREA & "," & FECHA & "," & ESTADO) Then
                    lines(i) = newline
                End If
            Next
            IO.File.WriteAllLines(jumbofile, lines)

            ReadTXT() ' carga el datagirdview de nuevo
            Clear()
            'EliminaLineaVacia() ' en caso de que haya una linea vacia, la quita del datagridview
        Else
            MsgBox("Se produjo un error al intentar actualizar la tarea", MessageBoxIcon.Error) ' Nos da error en caso de que el archivo de tareas
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        Dim textoABuscar As String = txtBuscar.Text.Trim()

        ' Realizamos la búsqueda en ambos DataGridViews
        BuscarEnDataGridView(dgvPendientes, textoABuscar)
        BuscarEnDataGridView(dgvCompletadas, textoABuscar)
    End Sub

    Private Sub BuscarEnDataGridView(dataGridView As DataGridView, textoABuscar As String)
        For Each fila As DataGridViewRow In dataGridView.Rows
            Dim filaVisible As Boolean = False

            For Each celda As DataGridViewCell In fila.Cells
                If celda.Value IsNot Nothing AndAlso celda.Value.ToString().Contains(textoABuscar) Then
                    ' Si la celda contiene el texto buscado, marcamos la fila como visible
                    filaVisible = True
                    Exit For ' Salimos del bucle ya que hemos encontrado una coincidencia
                End If
            Next

            ' Establecemos la visibilidad de la fila según si se encontró una coincidencia o no
            fila.Visible = filaVisible
        Next
    End Sub

    Private Sub dgvCompletadas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCompletadas.CellClick
        If dgvPendientes.RowCount > 0 Then ' si el datagridview tiene texto, los carga en el respectivo textbox y combobox
            LlenaTextoC()
            btnIngresar.Enabled = False
            btnActualizar.Enabled = True
        Else ' si es al contrario, limpia los campos
            Clear()
        End If
    End Sub

    Private Sub dgvPendientes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPendientes.CellClick
        If dgvPendientes.RowCount > 0 Then ' si el datagridview tiene texto, los carga en el respectivo textbox y combobox
            LlenaTextoP()
            btnIngresar.Enabled = False
            btnActualizar.Enabled = True
        Else ' si es al contrario, limpia los campos
            Clear()
        End If
    End Sub

    Private Sub LlenaTextoC()
        TAREA = dgvCompletadas.CurrentRow.Cells("TareaC").Value.ToString ' Lee la columna tarea de la linea seleccionada
        FECHA = dgvCompletadas.CurrentRow.Cells("FechaLimiteC").Value.ToString ' Lee la columna tarea de la linea seleccionada
        ESTADO = dgvCompletadas.CurrentRow.Cells("EstadoC").Value.ToString ' Lee la columna estado de la linea seleccionada

        ' asigna los valores a cada elemento
        txtTarea.Text = TAREA
        dtpFecha.Text = FECHA
        cboEstado.Text = ESTADO
    End Sub

    Private Sub LlenaTextoP()
        TAREA = dgvPendientes.CurrentRow.Cells("TareaP").Value.ToString ' Lee la columna tarea de la linea seleccionada
        FECHA = dgvPendientes.CurrentRow.Cells("FechaLimiteP").Value.ToString ' Lee la columna tarea de la linea seleccionada
        ESTADO = dgvPendientes.CurrentRow.Cells("EstadoP").Value.ToString ' Lee la columna estado de la linea seleccionada

        ' asigna los valores a cada elemento
        txtTarea.Text = TAREA
        dtpFecha.Text = FECHA
        cboEstado.Text = ESTADO
    End Sub
End Class
