<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSocios
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

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        btnNuevo = New Button()
        btnEditar = New Button()
        btnGuardar = New Button()
        btnEliminar = New Button()
        btnCancelat = New Button()
        txtBuscar = New TextBox()
        Label1 = New Label()
        cboEstado = New ComboBox()
        Button1 = New Button()
        DataGridView1 = New DataGridView()
        dgvSocios = New DataGridViewTextBoxColumn()
        Column1 = New DataGridViewTextBoxColumn()
        grpDatos = New GroupBox()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnNuevo
        ' 
        btnNuevo.Location = New Point(0, 0)
        btnNuevo.Margin = New Padding(4, 5, 4, 5)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New Size(107, 38)
        btnNuevo.TabIndex = 0
        btnNuevo.Text = "Nuevo"
        btnNuevo.UseVisualStyleBackColor = True
        ' 
        ' btnEditar
        ' 
        btnEditar.Location = New Point(116, 0)
        btnEditar.Margin = New Padding(4, 5, 4, 5)
        btnEditar.Name = "btnEditar"
        btnEditar.Size = New Size(107, 38)
        btnEditar.TabIndex = 1
        btnEditar.Text = "Editar"
        btnEditar.UseVisualStyleBackColor = True
        ' 
        ' btnGuardar
        ' 
        btnGuardar.Location = New Point(231, 0)
        btnGuardar.Margin = New Padding(4, 5, 4, 5)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(107, 38)
        btnGuardar.TabIndex = 2
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = True
        ' 
        ' btnEliminar
        ' 
        btnEliminar.Location = New Point(347, 0)
        btnEliminar.Margin = New Padding(4, 5, 4, 5)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(107, 38)
        btnEliminar.TabIndex = 3
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = True
        ' 
        ' btnCancelat
        ' 
        btnCancelat.Location = New Point(463, 0)
        btnCancelat.Margin = New Padding(4, 5, 4, 5)
        btnCancelat.Name = "btnCancelat"
        btnCancelat.Size = New Size(107, 38)
        btnCancelat.TabIndex = 4
        btnCancelat.Text = "Cancelar"
        btnCancelat.UseVisualStyleBackColor = True
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Location = New Point(724, 0)
        txtBuscar.Margin = New Padding(4, 5, 4, 5)
        txtBuscar.Name = "txtBuscar"
        txtBuscar.Size = New Size(228, 31)
        txtBuscar.TabIndex = 5
        txtBuscar.Text = "Cedula, nombre o apellido"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(657, 5)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(67, 25)
        Label1.TabIndex = 6
        Label1.Text = "Buscar:"
        ' 
        ' cboEstado
        ' 
        cboEstado.FormattingEnabled = True
        cboEstado.Location = New Point(980, 2)
        cboEstado.Margin = New Padding(4, 5, 4, 5)
        cboEstado.Name = "cboEstado"
        cboEstado.Size = New Size(171, 33)
        cboEstado.TabIndex = 7
        cboEstado.Text = "Estado Todos"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(1161, 2)
        Button1.Margin = New Padding(4, 5, 4, 5)
        Button1.Name = "Button1"
        Button1.Size = New Size(107, 38)
        Button1.TabIndex = 8
        Button1.Text = "Buscar"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {dgvSocios, Column1})
        DataGridView1.Location = New Point(-4, 48)
        DataGridView1.Margin = New Padding(4, 5, 4, 5)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 62
        DataGridView1.Size = New Size(811, 682)
        DataGridView1.TabIndex = 9
        ' 
        ' dgvSocios
        ' 
        dgvSocios.HeaderText = "ID"
        dgvSocios.MinimumWidth = 8
        dgvSocios.Name = "dgvSocios"
        dgvSocios.ReadOnly = True
        dgvSocios.Visible = False
        dgvSocios.Width = 150
        ' 
        ' Column1
        ' 
        Column1.HeaderText = "Cedula"
        Column1.MinimumWidth = 8
        Column1.Name = "Column1"
        Column1.ReadOnly = True
        Column1.Visible = False
        Column1.Width = 150
        ' 
        ' grpDatos
        ' 
        grpDatos.Location = New Point(821, 50)
        grpDatos.Margin = New Padding(4, 5, 4, 5)
        grpDatos.Name = "grpDatos"
        grpDatos.Padding = New Padding(4, 5, 4, 5)
        grpDatos.Size = New Size(539, 680)
        grpDatos.TabIndex = 10
        grpDatos.TabStop = False
        grpDatos.Text = "Datos del socio"
        ' 
        ' frmSocios
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1489, 847)
        Controls.Add(grpDatos)
        Controls.Add(DataGridView1)
        Controls.Add(Button1)
        Controls.Add(cboEstado)
        Controls.Add(Label1)
        Controls.Add(txtBuscar)
        Controls.Add(btnCancelat)
        Controls.Add(btnEliminar)
        Controls.Add(btnGuardar)
        Controls.Add(btnEditar)
        Controls.Add(btnNuevo)
        Margin = New Padding(4, 5, 4, 5)
        Name = "frmSocios"
        Text = "03"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnCancelat As Button
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cboEstado As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents dgvSocios As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents grpDatos As GroupBox

End Class