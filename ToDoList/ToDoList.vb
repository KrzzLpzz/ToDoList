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
        EliminaLineaVacia()
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


    Private Sub EliminaLineaVacia()
        ' esta funcion nos permite eliminar las lineas vacias que tenga nuestro archivo para que en datagridview no se muestren y no nos de error
        Dim strFile As String = File.ReadAllText("TAREAS.txt")
        strFile = Regex.Replace(strFile, "^\r|\n\r|\n$", "")
        File.WriteAllText("TAREAS.txt", strFile)
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
        EliminaLineaVacia()
    End Sub
End Class
