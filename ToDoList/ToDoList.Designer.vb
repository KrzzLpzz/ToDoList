<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ToDoList
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ToDoList))
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.cboEstado = New System.Windows.Forms.ComboBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnIngresar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTarea = New System.Windows.Forms.TextBox()
        Me.lblIngresar = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dgvCompletadas = New System.Windows.Forms.DataGridView()
        Me.TareaC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaLimiteC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadoC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvLoad = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvPendientes = New System.Windows.Forms.DataGridView()
        Me.TareaP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaLimiteP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadoP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AbrirAplicaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvCompletadas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLoad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewImageColumn1.HeaderText = "Column1"
        Me.DataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnEliminar)
        Me.GroupBox1.Controls.Add(Me.lblEstado)
        Me.GroupBox1.Controls.Add(Me.cboEstado)
        Me.GroupBox1.Controls.Add(Me.dtpFecha)
        Me.GroupBox1.Controls.Add(Me.btnActualizar)
        Me.GroupBox1.Controls.Add(Me.btnSalir)
        Me.GroupBox1.Controls.Add(Me.btnNuevo)
        Me.GroupBox1.Controls.Add(Me.btnIngresar)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtTarea)
        Me.GroupBox1.Controls.Add(Me.lblIngresar)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(623, 126)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Gestionar las Tareas"
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(355, 67)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(75, 34)
        Me.btnEliminar.TabIndex = 6
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Location = New System.Drawing.Point(436, 25)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(43, 13)
        Me.lblEstado.TabIndex = 9
        Me.lblEstado.Text = "Estado:"
        '
        'cboEstado
        '
        Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Items.AddRange(New Object() {"--SELECCIONAR--", "Completa", "Pendiente"})
        Me.cboEstado.Location = New System.Drawing.Point(439, 41)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(165, 21)
        Me.cboEstado.TabIndex = 2
        '
        'dtpFecha
        '
        Me.dtpFecha.CustomFormat = ""
        Me.dtpFecha.Location = New System.Drawing.Point(233, 41)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(200, 20)
        Me.dtpFecha.TabIndex = 1
        '
        'btnActualizar
        '
        Me.btnActualizar.Location = New System.Drawing.Point(193, 67)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(75, 34)
        Me.btnActualizar.TabIndex = 4
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(436, 67)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 34)
        Me.btnSalir.TabIndex = 7
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(274, 67)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 34)
        Me.btnNuevo.TabIndex = 5
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnIngresar
        '
        Me.btnIngresar.Location = New System.Drawing.Point(112, 67)
        Me.btnIngresar.Name = "btnIngresar"
        Me.btnIngresar.Size = New System.Drawing.Size(75, 34)
        Me.btnIngresar.TabIndex = 3
        Me.btnIngresar.Text = "Ingresar"
        Me.btnIngresar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(230, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha Limite:"
        '
        'txtTarea
        '
        Me.txtTarea.Location = New System.Drawing.Point(22, 41)
        Me.txtTarea.Name = "txtTarea"
        Me.txtTarea.Size = New System.Drawing.Size(205, 20)
        Me.txtTarea.TabIndex = 0
        '
        'lblIngresar
        '
        Me.lblIngresar.AutoSize = True
        Me.lblIngresar.Location = New System.Drawing.Point(19, 25)
        Me.lblIngresar.Name = "lblIngresar"
        Me.lblIngresar.Size = New System.Drawing.Size(84, 13)
        Me.lblIngresar.TabIndex = 0
        Me.lblIngresar.Text = "Ingresa tu tarea:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dgvCompletadas)
        Me.GroupBox3.Controls.Add(Me.dgvLoad)
        Me.GroupBox3.Location = New System.Drawing.Point(50, 333)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(561, 153)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tareas Completadas"
        '
        'dgvCompletadas
        '
        Me.dgvCompletadas.AllowUserToAddRows = False
        Me.dgvCompletadas.AllowUserToDeleteRows = False
        Me.dgvCompletadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCompletadas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TareaC, Me.FechaLimiteC, Me.EstadoC})
        Me.dgvCompletadas.Location = New System.Drawing.Point(25, 19)
        Me.dgvCompletadas.Name = "dgvCompletadas"
        Me.dgvCompletadas.ReadOnly = True
        Me.dgvCompletadas.Size = New System.Drawing.Size(510, 115)
        Me.dgvCompletadas.TabIndex = 0
        '
        'TareaC
        '
        Me.TareaC.Frozen = True
        Me.TareaC.HeaderText = "Tarea"
        Me.TareaC.Name = "TareaC"
        Me.TareaC.ReadOnly = True
        Me.TareaC.Width = 200
        '
        'FechaLimiteC
        '
        Me.FechaLimiteC.Frozen = True
        Me.FechaLimiteC.HeaderText = "Fecha Limite"
        Me.FechaLimiteC.Name = "FechaLimiteC"
        Me.FechaLimiteC.ReadOnly = True
        Me.FechaLimiteC.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.FechaLimiteC.Width = 165
        '
        'EstadoC
        '
        Me.EstadoC.Frozen = True
        Me.EstadoC.HeaderText = "Estado"
        Me.EstadoC.Name = "EstadoC"
        Me.EstadoC.ReadOnly = True
        Me.EstadoC.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'dgvLoad
        '
        Me.dgvLoad.AllowUserToAddRows = False
        Me.dgvLoad.AllowUserToDeleteRows = False
        Me.dgvLoad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLoad.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9})
        Me.dgvLoad.Location = New System.Drawing.Point(257, 87)
        Me.dgvLoad.Name = "dgvLoad"
        Me.dgvLoad.ReadOnly = True
        Me.dgvLoad.Size = New System.Drawing.Size(34, 25)
        Me.dgvLoad.TabIndex = 3
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.Frozen = True
        Me.DataGridViewTextBoxColumn7.HeaderText = "Tarea"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 200
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.Frozen = True
        Me.DataGridViewTextBoxColumn8.HeaderText = "Fecha Limite"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn8.Width = 165
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.Frozen = True
        Me.DataGridViewTextBoxColumn9.HeaderText = "Estado"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvPendientes)
        Me.GroupBox2.Location = New System.Drawing.Point(50, 174)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(561, 153)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tareas Pendientes"
        '
        'dgvPendientes
        '
        Me.dgvPendientes.AllowUserToAddRows = False
        Me.dgvPendientes.AllowUserToDeleteRows = False
        Me.dgvPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPendientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TareaP, Me.FechaLimiteP, Me.EstadoP})
        Me.dgvPendientes.Location = New System.Drawing.Point(25, 19)
        Me.dgvPendientes.Name = "dgvPendientes"
        Me.dgvPendientes.ReadOnly = True
        Me.dgvPendientes.Size = New System.Drawing.Size(510, 115)
        Me.dgvPendientes.TabIndex = 0
        '
        'TareaP
        '
        Me.TareaP.Frozen = True
        Me.TareaP.HeaderText = "Tarea"
        Me.TareaP.Name = "TareaP"
        Me.TareaP.ReadOnly = True
        Me.TareaP.Width = 200
        '
        'FechaLimiteP
        '
        Me.FechaLimiteP.Frozen = True
        Me.FechaLimiteP.HeaderText = "Fecha Limite"
        Me.FechaLimiteP.Name = "FechaLimiteP"
        Me.FechaLimiteP.ReadOnly = True
        Me.FechaLimiteP.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.FechaLimiteP.Width = 165
        '
        'EstadoP
        '
        Me.EstadoP.Frozen = True
        Me.EstadoP.HeaderText = "Estado"
        Me.EstadoP.Name = "EstadoP"
        Me.EstadoP.ReadOnly = True
        Me.EstadoP.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(252, 148)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(205, 20)
        Me.txtBuscar.TabIndex = 2
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.Location = New System.Drawing.Point(203, 151)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(43, 13)
        Me.lblBuscar.TabIndex = 5
        Me.lblBuscar.Text = "Buscar:"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Tareas Pendientes"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AbrirAplicaciónToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(160, 26)
        '
        'AbrirAplicaciónToolStripMenuItem
        '
        Me.AbrirAplicaciónToolStripMenuItem.Name = "AbrirAplicaciónToolStripMenuItem"
        Me.AbrirAplicaciónToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.AbrirAplicaciónToolStripMenuItem.Text = "Abrir Aplicación"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 5000
        '
        'ToDoList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(661, 502)
        Me.Controls.Add(Me.lblBuscar)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "ToDoList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de Tareas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgvCompletadas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLoad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridViewImageColumn1 As DataGridViewImageColumn
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnIngresar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtTarea As TextBox
    Friend WithEvents lblIngresar As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents dgvCompletadas As DataGridView
    Friend WithEvents btnActualizar As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dgvPendientes As DataGridView
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents lblEstado As Label
    Friend WithEvents btnEliminar As Button
    Friend WithEvents cboEstado As ComboBox
    Friend WithEvents dgvLoad As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents TareaC As DataGridViewTextBoxColumn
    Friend WithEvents FechaLimiteC As DataGridViewTextBoxColumn
    Friend WithEvents EstadoC As DataGridViewTextBoxColumn
    Friend WithEvents TareaP As DataGridViewTextBoxColumn
    Friend WithEvents FechaLimiteP As DataGridViewTextBoxColumn
    Friend WithEvents EstadoP As DataGridViewTextBoxColumn
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents lblBuscar As Label
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents AbrirAplicaciónToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Timer1 As Timer
End Class
