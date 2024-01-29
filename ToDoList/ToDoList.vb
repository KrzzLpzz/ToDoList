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
        ReadTXT() ' lee el texto del archivo de texto

        cboEstado.SelectedIndex = 0 ' Configura el valor predeterminado seleccionado
    End Sub

    ' Funcion para leer el contenido del archivo de texto
    Private Sub ReadTXT()
        ' Limpia y reestablece los elementos 
        Clear()

        ' Limpiar los DataGridView
        dgvCompletadas.Rows.Clear()
        dgvPendientes.Rows.Clear()

        ' Lee el archivo de texto y procesa las tareas
        Using sr As New StreamReader("TAREAS.txt")
            Dim linea As String
            While Not sr.EndOfStream ' Mientras no llegue a la ultima linea, no va a dejar de leer.
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

    ' Boton para ingresar nuevos datos
    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        ' Hacemos uso de un if para asegurarnos que el usuario establecio un estado.
        If cboEstado.Text = "--SELECCIONAR--" Then
            MsgBox("Tienes que establecer un valor para el estado que sea diferente a seleccionar", MessageBoxIcon.Error)
        Else
            ' Guardamos el texto concatenado a nuestro archivo de texto.
            File.AppendAllText("TAREAS.txt", Environment.NewLine + (txtTarea.Text & "," & dtpFecha.Text & "," & cboEstado.Text))

            ReadTXT() ' Leemos nuevamente el archivo
        End If
    End Sub

    ' boton para limpiar
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Clear()
    End Sub

    ' Funcion para reestablecer y limpiar elementos
    Private Sub Clear()
        txtTarea.Text = ""
        cboEstado.Text = "--SELECCIONAR--"
        btnActualizar.Enabled = False
        txtTarea.Focus()
        btnIngresar.Enabled = True
        EliminaLineaVacia()
        txtBuscar.Clear()
    End Sub

    ' Funcion para leer nuestro archivo de texto y en caso de que existan lineas en blanco esto los eliminará
    Private Sub EliminaLineaVacia()
        Dim strFile As String = File.ReadAllText("TAREAS.txt")
        strFile = Regex.Replace(strFile, "^\r|\n\r|\n$", "")
        File.WriteAllText("TAREAS.txt", strFile)
    End Sub

    ' Boton de Salir
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If MessageBox.Show("¿Está seguro que desea salir?", "Confirmar Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ' Cierra la aplicación
            Application.Exit()
        End If
    End Sub

    ' Boton de Eliminar
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

    ' Funcion para filtrar nuestro archivo de texto y eliminar la linea que deseemos
    Function FilterFile(ByVal sFile As String, ByVal sFilter As String) As Boolean
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

    ' Boton de actualizar
    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        ' Hacemos uso de un if para asegurarnos que el usuario coloco un estado
        If cboEstado.Text = "--SELECCIONAR--" Then
            MsgBox("Tienes que establecer un valor para el estado que sea diferente a seleccionar", MessageBoxIcon.Error)
        Else
            Update() ' ejecucion de la funcion de actualizar
        End If
    End Sub

    ' Funcion para actualizar
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

            ReadTXT() ' el archivo de texto nuevamente
            Clear() ' reestablecemos los elementos
        Else
            MsgBox("Se produjo un error al intentar actualizar la tarea", MessageBoxIcon.Error) ' Nos da error en caso de que el archivo de tareas
        End If
    End Sub

    ' Hacemos uso de la propiedad TextChanged del TextBox de busqueda para buscar elementos en los datagridview
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        Dim textoABuscar As String = txtBuscar.Text.Trim()

        ' Realizamos la búsqueda en ambos DataGridViews
        BuscarEnDataGridView(dgvPendientes, textoABuscar)
        BuscarEnDataGridView(dgvCompletadas, textoABuscar)
    End Sub

    ' Funcion para buscar elementos en los datagridview
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

    ' Usamos la propiedad CellClick del DGV Completadas para poder seleccionar un dato
    Private Sub dgvCompletadas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCompletadas.CellClick
        If dgvPendientes.RowCount > 0 Then ' si el datagridview tiene texto, los carga en el respectivo textbox y combobox
            LlenaTextoC()
            btnIngresar.Enabled = False
            btnActualizar.Enabled = True
        Else ' si es al contrario, limpia los campos
            Clear()
        End If
    End Sub

    ' Usamos la propiedad CellClick del DGV Pendientes para poder seleccionar un dato
    Private Sub dgvPendientes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPendientes.CellClick
        If dgvPendientes.RowCount > 0 Then ' si el datagridview tiene texto, los carga en el respectivo textbox y combobox
            LlenaTextoP()
            btnIngresar.Enabled = False
            btnActualizar.Enabled = True
        Else ' si es al contrario, limpia los campos
            Clear()
        End If
    End Sub

    ' Funcion para traer la informacion de la fila seleccionada del DGV Completadas
    Private Sub LlenaTextoC()
        TAREA = dgvCompletadas.CurrentRow.Cells("TareaC").Value.ToString ' Lee la columna tarea de la linea seleccionada
        FECHA = dgvCompletadas.CurrentRow.Cells("FechaLimiteC").Value.ToString ' Lee la columna tarea de la linea seleccionada
        ESTADO = dgvCompletadas.CurrentRow.Cells("EstadoC").Value.ToString ' Lee la columna estado de la linea seleccionada

        ' Asigna los valores a cada elemento
        txtTarea.Text = TAREA
        dtpFecha.Text = FECHA
        cboEstado.Text = ESTADO
    End Sub

    ' Funcion para traer la informacion de la fila seleccionada del DGV Pendientes
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
