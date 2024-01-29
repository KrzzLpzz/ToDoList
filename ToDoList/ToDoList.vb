Imports System.IO
Imports System.Text.RegularExpressions

Public Class ToDoList
    Dim i As Integer = 0 ' Variable para controlar el ciclo for de la lectura de los datos del archivo de texto

    Dim dt As DataTable ' Variable para el datatable

    Dim _TAREA As String ' Variable para almacenar las tareas
    Dim _ESTADO As String ' Variable para almacenar el estado
    Private Sub ToDoList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LeerTXT2()
    End Sub

    Private Sub LeerTXT2()
        DataGridView1.Rows.Clear()
        DataGridView2.Rows.Clear()
        Dim ReadFile As StreamReader
        ReadFile = New StreamReader("TAREAS.txt")
        While Not ReadFile.EndOfStream
            Dim cadena As String = ReadFile.ReadLine
            Dim leer As String() = cadena.Split(New Char() {","})
            DataGridView1.Rows.Add(leer)
        End While

        ReadFile.Close()
        testeo()
    End Sub

    Private Sub testeo()

        ' Paso 1: Crear un nuevo DataTable
        Dim newDataTable As New DataTable()

        newDataTable.Clear()

        ' Añadir las primeras tres columnas al DataTable
        For i As Integer = 0 To 2 ' Solo las primeras tres columnas
            newDataTable.Columns.Add(DataGridView1.Columns(i).HeaderText)
        Next

        ' Añadir filas al DataTable
        For Each row As DataGridViewRow In DataGridView1.Rows
            Dim newRow As DataRow = newDataTable.Rows.Add()
            For i As Integer = 0 To 2 ' Solo las primeras tres columnas
                newRow(i) = row.Cells(i).Value
            Next
        Next

        ' Desvincular el origen de datos del DataGridView2
        DataGridView2.DataSource = Nothing

        ' Agregar las filas al DataGridView2
        For Each row As DataRow In newDataTable.Rows
            DataGridView2.Rows.Add(row.ItemArray)
        Next

        ' Vincular nuevamente el DataGridView2 al origen de datos
        ' Solo si necesitas mantener la capacidad de editar las celdas
        ' DataGridView3.DataSource = newDataTable
    End Sub

    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        ' Esta linea nos permite concatenar el textbox y el combobox para guardarlos en una nueva linea en nuestro archivo de texto
        File.AppendAllText("TAREAS.txt", Environment.NewLine + (txtTarea.Text & "," & dtpFecha.Text))

        LeerTXT2()
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

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Try
            If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 Then
                Dim columna As DataGridViewColumn = DataGridView1.Columns(e.ColumnIndex)

                If columna.Name = "Editar" Then
                    'Dim fila As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                    ' txtTarea.Text = fila.Cells(0).Value.ToString()
                ElseIf columna.Name = "Completar" Then
                    ' Dim fila As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                    '  fila.Cells(0).Value = txtTarea.Text
                ElseIf columna.Name = "Eliminar" Then
                    FilterFile("TAREAS.txt", txtTarea.Text)
                    MsgBox("Tarea eliminada correctamente")
                    LeerTXT2()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 Then
                Dim columna As DataGridViewColumn = DataGridView1.Columns(e.ColumnIndex)

                If columna.Name = "Editar" Then
                    'Dim fila As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                    ' txtTarea.Text = fila.Cells(0).Value.ToString()
                ElseIf columna.Name = "Completar" Then
                    ' Dim fila As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                    '  fila.Cells(0).Value = txtTarea.Text
                ElseIf columna.Name = "Eliminar" Then
                    FilterFile("TAREAS.txt", txtTarea.Text)
                    MsgBox("Tarea eliminada correctamente")
                    LeerTXT2()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Try
            If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 Then
                Dim columna As DataGridViewColumn = DataGridView1.Columns(e.ColumnIndex)

                If columna.Name = "Editar" Then
                    'Dim fila As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                    ' txtTarea.Text = fila.Cells(0).Value.ToString()
                ElseIf columna.Name = "Completar" Then
                    ' Dim fila As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                    '  fila.Cells(0).Value = txtTarea.Text
                ElseIf columna.Name = "Eliminar" Then
                    FilterFile("TAREAS.txt", txtTarea.Text)
                    MsgBox("Tarea eliminada correctamente")
                    LeerTXT2()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        FilterFile("TAREAS.txt", txtTarea.Text)
        MsgBox("Tarea eliminada correctamente")
        LeerTXT2()
    End Sub
End Class
