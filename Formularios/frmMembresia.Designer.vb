<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMembresia
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        txtSocios = New TextBox()
        txtSocio = New Label()
        btnBuscarSocio = New Button()
        GroupBox1 = New GroupBox()
        txtFechaVencimiento = New TextBox()
        txtFechaInicio = New TextBox()
        lblEstado = New Label()
        cmbEstado = New ComboBox()
        cmbTipoMembresia = New ComboBox()
        btnRenovar = New Button()
        btnSuspender = New Button()
        btnCancelar = New Button()
        txtPrecio = New TextBox()
        txtDuracion = New TextBox()
        btnRegistrar = New Button()
        lblPrecio = New Label()
        lblDuracion = New Label()
        lblFechaVencimient = New Label()
        lblFechaInicio = New Label()
        lblTipoMembresia = New Label()
        dgvMembresias = New DataGridView()
        Label6 = New Label()
        GroupBox2 = New GroupBox()
        pnlPago = New Panel()
        pnlSaldo = New Panel()
        pnlTotal = New Panel()
        cmbMetodoPago = New ComboBox()
        btnImprimirRecibo = New Button()
        btnAnularPago = New Button()
        btnRegistrarPago = New Button()
        txtObservacion = New TextBox()
        txtReferencia = New TextBox()
        txtMonto = New TextBox()
        lblObservacion = New Label()
        lblMonto = New Label()
        Label11 = New Label()
        lblReferencia = New Label()
        Label12 = New Label()
        MySqlDataAdapter1 = New MySqlConnector.MySqlDataAdapter()
        dgvPagos = New DataGridView()
        StatusStrip1 = New StatusStrip()
        ToolStripStatusLabel1 = New ToolStripStatusLabel()
        ToolStripStatusLabel2 = New ToolStripStatusLabel()
        ToolStripStatusLabel3 = New ToolStripStatusLabel()
        ToolStripStatusLabel4 = New ToolStripStatusLabel()
        Label14 = New Label()
        GroupBox1.SuspendLayout()
        CType(dgvMembresias, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox2.SuspendLayout()
        CType(dgvPagos, ComponentModel.ISupportInitialize).BeginInit()
        StatusStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtSocios
        ' 
        txtSocios.Location = New Point(100, 31)
        txtSocios.Margin = New Padding(4, 5, 4, 5)
        txtSocios.Name = "txtSocios"
        txtSocios.Size = New Size(233, 31)
        txtSocios.TabIndex = 0
        ' 
        ' txtSocio
        ' 
        txtSocio.AutoSize = True
        txtSocio.Font = New Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtSocio.Location = New Point(24, 34)
        txtSocio.Margin = New Padding(4, 0, 4, 0)
        txtSocio.Name = "txtSocio"
        txtSocio.Size = New Size(74, 25)
        txtSocio.TabIndex = 1
        txtSocio.Text = "Socios:"
        ' 
        ' btnBuscarSocio
        ' 
        btnBuscarSocio.Location = New Point(341, 27)
        btnBuscarSocio.Margin = New Padding(4, 5, 4, 5)
        btnBuscarSocio.Name = "btnBuscarSocio"
        btnBuscarSocio.Size = New Size(133, 38)
        btnBuscarSocio.TabIndex = 2
        btnBuscarSocio.Text = "Busacr socio"
        btnBuscarSocio.UseVisualStyleBackColor = True
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(txtFechaVencimiento)
        GroupBox1.Controls.Add(txtFechaInicio)
        GroupBox1.Controls.Add(lblEstado)
        GroupBox1.Controls.Add(cmbEstado)
        GroupBox1.Controls.Add(cmbTipoMembresia)
        GroupBox1.Controls.Add(btnRenovar)
        GroupBox1.Controls.Add(btnSuspender)
        GroupBox1.Controls.Add(btnCancelar)
        GroupBox1.Controls.Add(txtPrecio)
        GroupBox1.Controls.Add(txtDuracion)
        GroupBox1.Controls.Add(btnRegistrar)
        GroupBox1.Controls.Add(lblPrecio)
        GroupBox1.Controls.Add(lblDuracion)
        GroupBox1.Controls.Add(lblFechaVencimient)
        GroupBox1.Controls.Add(lblFechaInicio)
        GroupBox1.Controls.Add(lblTipoMembresia)
        GroupBox1.Location = New Point(17, 67)
        GroupBox1.Margin = New Padding(4, 5, 4, 5)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(4, 5, 4, 5)
        GroupBox1.Size = New Size(841, 495)
        GroupBox1.TabIndex = 3
        GroupBox1.TabStop = False
        GroupBox1.Text = "Membresia"
        ' 
        ' txtFechaVencimiento
        ' 
        txtFechaVencimiento.Location = New Point(180, 188)
        txtFechaVencimiento.Name = "txtFechaVencimiento"
        txtFechaVencimiento.Size = New Size(323, 31)
        txtFechaVencimiento.TabIndex = 18
        ' 
        ' txtFechaInicio
        ' 
        txtFechaInicio.Location = New Point(180, 115)
        txtFechaInicio.Name = "txtFechaInicio"
        txtFechaInicio.Size = New Size(323, 31)
        txtFechaInicio.TabIndex = 17
        ' 
        ' lblEstado
        ' 
        lblEstado.AutoSize = True
        lblEstado.Location = New Point(18, 262)
        lblEstado.Name = "lblEstado"
        lblEstado.Size = New Size(66, 25)
        lblEstado.TabIndex = 16
        lblEstado.Text = "Estado"
        ' 
        ' cmbEstado
        ' 
        cmbEstado.FormattingEnabled = True
        cmbEstado.Location = New Point(180, 259)
        cmbEstado.Name = "cmbEstado"
        cmbEstado.Size = New Size(323, 33)
        cmbEstado.TabIndex = 15
        ' 
        ' cmbTipoMembresia
        ' 
        cmbTipoMembresia.FormattingEnabled = True
        cmbTipoMembresia.Location = New Point(203, 45)
        cmbTipoMembresia.Name = "cmbTipoMembresia"
        cmbTipoMembresia.Size = New Size(609, 33)
        cmbTipoMembresia.TabIndex = 14
        ' 
        ' btnRenovar
        ' 
        btnRenovar.Location = New Point(225, 360)
        btnRenovar.Margin = New Padding(4, 5, 4, 5)
        btnRenovar.Name = "btnRenovar"
        btnRenovar.Size = New Size(137, 52)
        btnRenovar.TabIndex = 13
        btnRenovar.Text = "Renovar"
        btnRenovar.UseVisualStyleBackColor = True
        ' 
        ' btnSuspender
        ' 
        btnSuspender.Location = New Point(427, 361)
        btnSuspender.Margin = New Padding(4, 5, 4, 5)
        btnSuspender.Name = "btnSuspender"
        btnSuspender.Size = New Size(137, 51)
        btnSuspender.TabIndex = 12
        btnSuspender.Text = "Suspender"
        btnSuspender.UseVisualStyleBackColor = True
        ' 
        ' btnCancelar
        ' 
        btnCancelar.Location = New Point(631, 361)
        btnCancelar.Margin = New Padding(4, 5, 4, 5)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(137, 51)
        btnCancelar.TabIndex = 11
        btnCancelar.Text = "Cancelar"
        btnCancelar.UseVisualStyleBackColor = True
        ' 
        ' txtPrecio
        ' 
        txtPrecio.Location = New Point(604, 188)
        txtPrecio.Margin = New Padding(4, 5, 4, 5)
        txtPrecio.Name = "txtPrecio"
        txtPrecio.Size = New Size(208, 31)
        txtPrecio.TabIndex = 8
        ' 
        ' txtDuracion
        ' 
        txtDuracion.Location = New Point(604, 112)
        txtDuracion.Margin = New Padding(4, 5, 4, 5)
        txtDuracion.Name = "txtDuracion"
        txtDuracion.Size = New Size(208, 31)
        txtDuracion.TabIndex = 9
        ' 
        ' btnRegistrar
        ' 
        btnRegistrar.Location = New Point(36, 359)
        btnRegistrar.Margin = New Padding(4, 5, 4, 5)
        btnRegistrar.Name = "btnRegistrar"
        btnRegistrar.Size = New Size(137, 53)
        btnRegistrar.TabIndex = 10
        btnRegistrar.Text = "Registrar"
        btnRegistrar.UseVisualStyleBackColor = True
        ' 
        ' lblPrecio
        ' 
        lblPrecio.AutoSize = True
        lblPrecio.Location = New Point(510, 191)
        lblPrecio.Margin = New Padding(4, 0, 4, 0)
        lblPrecio.Name = "lblPrecio"
        lblPrecio.Size = New Size(86, 25)
        lblPrecio.TabIndex = 8
        lblPrecio.Text = "Precio C$"
        ' 
        ' lblDuracion
        ' 
        lblDuracion.AutoSize = True
        lblDuracion.Location = New Point(513, 115)
        lblDuracion.Margin = New Padding(4, 0, 4, 0)
        lblDuracion.Name = "lblDuracion"
        lblDuracion.Size = New Size(83, 25)
        lblDuracion.TabIndex = 9
        lblDuracion.Text = "Duracion"
        ' 
        ' lblFechaVencimient
        ' 
        lblFechaVencimient.AutoSize = True
        lblFechaVencimient.Location = New Point(15, 194)
        lblFechaVencimient.Margin = New Padding(4, 0, 4, 0)
        lblFechaVencimient.Name = "lblFechaVencimient"
        lblFechaVencimient.Size = New Size(158, 25)
        lblFechaVencimient.TabIndex = 2
        lblFechaVencimient.Text = "Fecha vencimiento"
        ' 
        ' lblFechaInicio
        ' 
        lblFechaInicio.AutoSize = True
        lblFechaInicio.Location = New Point(15, 118)
        lblFechaInicio.Margin = New Padding(4, 0, 4, 0)
        lblFechaInicio.Name = "lblFechaInicio"
        lblFechaInicio.Size = New Size(103, 25)
        lblFechaInicio.TabIndex = 1
        lblFechaInicio.Text = "Fecha inicio"
        ' 
        ' lblTipoMembresia
        ' 
        lblTipoMembresia.AutoSize = True
        lblTipoMembresia.Location = New Point(9, 52)
        lblTipoMembresia.Margin = New Padding(4, 0, 4, 0)
        lblTipoMembresia.Name = "lblTipoMembresia"
        lblTipoMembresia.Size = New Size(159, 25)
        lblTipoMembresia.TabIndex = 0
        lblTipoMembresia.Text = "Tipo de menbresia"
        ' 
        ' dgvMembresias
        ' 
        dgvMembresias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvMembresias.Location = New Point(13, 663)
        dgvMembresias.Margin = New Padding(4, 5, 4, 5)
        dgvMembresias.Name = "dgvMembresias"
        dgvMembresias.RowHeadersWidth = 62
        dgvMembresias.Size = New Size(845, 386)
        dgvMembresias.TabIndex = 4
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(26, 624)
        Label6.Margin = New Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(314, 25)
        Label6.TabIndex = 5
        Label6.Text = "Historial de membresias del socio"
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(pnlPago)
        GroupBox2.Controls.Add(pnlSaldo)
        GroupBox2.Controls.Add(pnlTotal)
        GroupBox2.Controls.Add(cmbMetodoPago)
        GroupBox2.Controls.Add(btnImprimirRecibo)
        GroupBox2.Controls.Add(btnAnularPago)
        GroupBox2.Controls.Add(btnRegistrarPago)
        GroupBox2.Controls.Add(txtObservacion)
        GroupBox2.Controls.Add(txtReferencia)
        GroupBox2.Controls.Add(txtMonto)
        GroupBox2.Controls.Add(lblObservacion)
        GroupBox2.Controls.Add(lblMonto)
        GroupBox2.Controls.Add(Label11)
        GroupBox2.Controls.Add(lblReferencia)
        GroupBox2.Controls.Add(Label12)
        GroupBox2.Location = New Point(878, 67)
        GroupBox2.Margin = New Padding(4, 5, 4, 5)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Padding = New Padding(4, 5, 4, 5)
        GroupBox2.Size = New Size(842, 495)
        GroupBox2.TabIndex = 4
        GroupBox2.TabStop = False
        GroupBox2.Text = "Registrar pago"
        ' 
        ' pnlPago
        ' 
        pnlPago.Location = New Point(321, 90)
        pnlPago.Name = "pnlPago"
        pnlPago.Size = New Size(224, 108)
        pnlPago.TabIndex = 9
        ' 
        ' pnlSaldo
        ' 
        pnlSaldo.Location = New Point(585, 90)
        pnlSaldo.Name = "pnlSaldo"
        pnlSaldo.Size = New Size(216, 108)
        pnlSaldo.TabIndex = 22
        ' 
        ' pnlTotal
        ' 
        pnlTotal.Location = New Point(60, 90)
        pnlTotal.Name = "pnlTotal"
        pnlTotal.Size = New Size(218, 108)
        pnlTotal.TabIndex = 21
        ' 
        ' cmbMetodoPago
        ' 
        cmbMetodoPago.FormattingEnabled = True
        cmbMetodoPago.Location = New Point(506, 221)
        cmbMetodoPago.Name = "cmbMetodoPago"
        cmbMetodoPago.Size = New Size(311, 33)
        cmbMetodoPago.TabIndex = 20
        ' 
        ' btnImprimirRecibo
        ' 
        btnImprimirRecibo.Location = New Point(567, 405)
        btnImprimirRecibo.Margin = New Padding(4, 5, 4, 5)
        btnImprimirRecibo.Name = "btnImprimirRecibo"
        btnImprimirRecibo.Size = New Size(166, 65)
        btnImprimirRecibo.TabIndex = 19
        btnImprimirRecibo.Text = "Imprimir recibo"
        btnImprimirRecibo.UseVisualStyleBackColor = True
        ' 
        ' btnAnularPago
        ' 
        btnAnularPago.BackColor = Color.LightCoral
        btnAnularPago.Location = New Point(356, 405)
        btnAnularPago.Margin = New Padding(4, 5, 4, 5)
        btnAnularPago.Name = "btnAnularPago"
        btnAnularPago.Size = New Size(166, 65)
        btnAnularPago.TabIndex = 18
        btnAnularPago.Text = "Anular pago"
        btnAnularPago.UseVisualStyleBackColor = False
        ' 
        ' btnRegistrarPago
        ' 
        btnRegistrarPago.BackColor = SystemColors.GradientActiveCaption
        btnRegistrarPago.Location = New Point(134, 405)
        btnRegistrarPago.Margin = New Padding(4, 5, 4, 5)
        btnRegistrarPago.Name = "btnRegistrarPago"
        btnRegistrarPago.Size = New Size(166, 65)
        btnRegistrarPago.TabIndex = 17
        btnRegistrarPago.Text = "Registrar pago"
        btnRegistrarPago.UseVisualStyleBackColor = False
        ' 
        ' txtObservacion
        ' 
        txtObservacion.Location = New Point(134, 353)
        txtObservacion.Margin = New Padding(4, 5, 4, 5)
        txtObservacion.Name = "txtObservacion"
        txtObservacion.Size = New Size(683, 31)
        txtObservacion.TabIndex = 16
        ' 
        ' txtReferencia
        ' 
        txtReferencia.Location = New Point(109, 292)
        txtReferencia.Margin = New Padding(4, 5, 4, 5)
        txtReferencia.Name = "txtReferencia"
        txtReferencia.Size = New Size(708, 31)
        txtReferencia.TabIndex = 15
        ' 
        ' txtMonto
        ' 
        txtMonto.Location = New Point(103, 223)
        txtMonto.Margin = New Padding(4, 5, 4, 5)
        txtMonto.Name = "txtMonto"
        txtMonto.Size = New Size(312, 31)
        txtMonto.TabIndex = 8
        ' 
        ' lblObservacion
        ' 
        lblObservacion.AutoSize = True
        lblObservacion.Location = New Point(9, 358)
        lblObservacion.Margin = New Padding(4, 0, 4, 0)
        lblObservacion.Name = "lblObservacion"
        lblObservacion.Size = New Size(111, 25)
        lblObservacion.TabIndex = 10
        lblObservacion.Text = "Observacion"
        ' 
        ' lblMonto
        ' 
        lblMonto.AutoSize = True
        lblMonto.Location = New Point(9, 223)
        lblMonto.Margin = New Padding(4, 0, 4, 0)
        lblMonto.Name = "lblMonto"
        lblMonto.Size = New Size(92, 25)
        lblMonto.TabIndex = 11
        lblMonto.Text = "Monto C$"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(9, 53)
        Label11.Margin = New Padding(4, 0, 4, 0)
        Label11.Name = "Label11"
        Label11.Size = New Size(100, 25)
        Label11.TabIndex = 12
        Label11.Text = "Membresia"
        ' 
        ' lblReferencia
        ' 
        lblReferencia.AutoSize = True
        lblReferencia.Location = New Point(9, 292)
        lblReferencia.Margin = New Padding(4, 0, 4, 0)
        lblReferencia.Name = "lblReferencia"
        lblReferencia.Size = New Size(92, 25)
        lblReferencia.TabIndex = 14
        lblReferencia.Text = "Referencia"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(423, 226)
        Label12.Margin = New Padding(4, 0, 4, 0)
        Label12.Name = "Label12"
        Label12.Size = New Size(76, 25)
        Label12.TabIndex = 13
        Label12.Text = "Metodo"
        ' 
        ' MySqlDataAdapter1
        ' 
        MySqlDataAdapter1.DeleteCommand = Nothing
        MySqlDataAdapter1.InsertCommand = Nothing
        MySqlDataAdapter1.SelectCommand = Nothing
        MySqlDataAdapter1.UpdateBatchSize = 0
        MySqlDataAdapter1.UpdateCommand = Nothing
        ' 
        ' dgvPagos
        ' 
        dgvPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPagos.Location = New Point(878, 663)
        dgvPagos.Margin = New Padding(4, 5, 4, 5)
        dgvPagos.Name = "dgvPagos"
        dgvPagos.RowHeadersWidth = 62
        dgvPagos.Size = New Size(842, 386)
        dgvPagos.TabIndex = 6
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.ImageScalingSize = New Size(24, 24)
        StatusStrip1.Items.AddRange(New ToolStripItem() {ToolStripStatusLabel1, ToolStripStatusLabel2, ToolStripStatusLabel3, ToolStripStatusLabel4})
        StatusStrip1.Location = New Point(0, 1138)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Padding = New Padding(1, 0, 20, 0)
        StatusStrip1.Size = New Size(1770, 32)
        StatusStrip1.TabIndex = 7
        StatusStrip1.Text = "StatusStrip1"
        ' 
        ' ToolStripStatusLabel1
        ' 
        ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        ToolStripStatusLabel1.Size = New Size(93, 25)
        ToolStripStatusLabel1.Text = "Socio ID:3"
        ' 
        ' ToolStripStatusLabel2
        ' 
        ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        ToolStripStatusLabel2.Size = New Size(175, 25)
        ToolStripStatusLabel2.Text = "Membresia actual:41"
        ' 
        ' ToolStripStatusLabel3
        ' 
        ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        ToolStripStatusLabel3.Size = New Size(145, 25)
        ToolStripStatusLabel3.Text = "Saldo pendiente:"
        ' 
        ' ToolStripStatusLabel4
        ' 
        ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        ToolStripStatusLabel4.Size = New Size(72, 25)
        ToolStripStatusLabel4.Text = "Usuario"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Font = New Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label14.Location = New Point(917, 624)
        Label14.Margin = New Padding(4, 0, 4, 0)
        Label14.Name = "Label14"
        Label14.Size = New Size(336, 25)
        Label14.TabIndex = 8
        Label14.Text = "Pagos de la membresia seleccionada"
        ' 
        ' frmMembresia
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1770, 1170)
        Controls.Add(Label14)
        Controls.Add(StatusStrip1)
        Controls.Add(dgvPagos)
        Controls.Add(GroupBox2)
        Controls.Add(Label6)
        Controls.Add(dgvMembresias)
        Controls.Add(GroupBox1)
        Controls.Add(btnBuscarSocio)
        Controls.Add(txtSocio)
        Controls.Add(txtSocios)
        Margin = New Padding(4, 5, 4, 5)
        Name = "frmMembresia"
        Text = "Membresias y Pagos"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(dgvMembresias, ComponentModel.ISupportInitialize).EndInit()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        CType(dgvPagos, ComponentModel.ISupportInitialize).EndInit()
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtSocios As TextBox
    Friend WithEvents txtSocio As Label
    Friend WithEvents btnBuscarSocio As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblFechaVencimient As Label
    Friend WithEvents lblFechaInicio As Label
    Friend WithEvents lblTipoMembresia As Label
    Friend WithEvents dgvMembresias As DataGridView
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents MySqlDataAdapter1 As MySqlConnector.MySqlDataAdapter
    Friend WithEvents lblPrecio As Label
    Friend WithEvents lblDuracion As Label
    Friend WithEvents lblObservacion As Label
    Friend WithEvents lblMonto As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents lblReferencia As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents dgvPagos As DataGridView
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents btnRegistrar As Button
    Friend WithEvents btnRenovar As Button
    Friend WithEvents btnSuspender As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents txtPrecio As TextBox
    Friend WithEvents txtDuracion As TextBox
    Friend WithEvents btnImprimirRecibo As Button
    Friend WithEvents btnAnularPago As Button
    Friend WithEvents btnRegistrarPago As Button
    Friend WithEvents txtObservacion As TextBox
    Friend WithEvents txtReferencia As TextBox
    Friend WithEvents txtMonto As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents cmbTipoMembresia As ComboBox
    Friend WithEvents cmbMetodoPago As ComboBox
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents pnlPago As Panel
    Friend WithEvents pnlSaldo As Panel
    Friend WithEvents pnlTotal As Panel
    Friend WithEvents lblEstado As Label
    Friend WithEvents txtFechaVencimiento As TextBox
    Friend WithEvents txtFechaInicio As TextBox
End Class
