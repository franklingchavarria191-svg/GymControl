<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPortalSocio
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
        btnCambiarContrasena = New Button()
        btnCerrarSesion = New Button()
        Panel1 = New Panel()
        lblSaldoPendiente = New Label()
        lblPagado = New Label()
        lblTotalMembresia = New Label()
        lblEstadoCuenta = New Label()
        Panel2 = New Panel()
        lblMiMembresia = New Label()
        lblDiasRestantes = New Label()
        prgMembresia = New ProgressBar()
        lblIncluyeClases = New Label()
        lblVence = New Label()
        lblInicio = New Label()
        lblTipoMembresia = New Label()
        Label7 = New Label()
        Label8 = New Label()
        dgvPagos = New DataGridView()
        Column1 = New DataGridViewTextBoxColumn()
        Column2 = New DataGridViewTextBoxColumn()
        Column3 = New DataGridViewTextBoxColumn()
        Column4 = New DataGridViewTextBoxColumn()
        dgvClases = New DataGridView()
        Column5 = New DataGridViewTextBoxColumn()
        Column6 = New DataGridViewTextBoxColumn()
        Column7 = New DataGridViewTextBoxColumn()
        Column8 = New DataGridViewTextBoxColumn()
        Column9 = New DataGridViewTextBoxColumn()
        StatusStrip1 = New StatusStrip()
        stsUsuario = New ToolStripStatusLabel()
        stsRol = New ToolStripStatusLabel()
        stsModo = New ToolStripStatusLabel()
        lblNombreSocio = New Label()
        lblInfoSocio = New Label()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        lblEstadoMembresia = New Label()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        CType(dgvPagos, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvClases, ComponentModel.ISupportInitialize).BeginInit()
        StatusStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnCambiarContrasena
        ' 
        btnCambiarContrasena.Location = New Point(839, 20)
        btnCambiarContrasena.Margin = New Padding(4, 5, 4, 5)
        btnCambiarContrasena.Name = "btnCambiarContrasena"
        btnCambiarContrasena.Size = New Size(183, 57)
        btnCambiarContrasena.TabIndex = 0
        btnCambiarContrasena.Text = "Cambiar contraseña"
        btnCambiarContrasena.UseVisualStyleBackColor = True
        ' 
        ' btnCerrarSesion
        ' 
        btnCerrarSesion.BackColor = Color.LightCoral
        btnCerrarSesion.Location = New Point(1031, 20)
        btnCerrarSesion.Margin = New Padding(4, 5, 4, 5)
        btnCerrarSesion.Name = "btnCerrarSesion"
        btnCerrarSesion.Size = New Size(164, 57)
        btnCerrarSesion.TabIndex = 1
        btnCerrarSesion.Text = "Cerrar sesion"
        btnCerrarSesion.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(lblEstadoMembresia)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(lblSaldoPendiente)
        Panel1.Controls.Add(lblPagado)
        Panel1.Controls.Add(lblTotalMembresia)
        Panel1.Controls.Add(lblEstadoCuenta)
        Panel1.Location = New Point(651, 108)
        Panel1.Margin = New Padding(4, 5, 4, 5)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(814, 312)
        Panel1.TabIndex = 2
        ' 
        ' lblSaldoPendiente
        ' 
        lblSaldoPendiente.AutoSize = True
        lblSaldoPendiente.Location = New Point(403, 230)
        lblSaldoPendiente.Margin = New Padding(4, 0, 4, 0)
        lblSaldoPendiente.Name = "lblSaldoPendiente"
        lblSaldoPendiente.Size = New Size(141, 25)
        lblSaldoPendiente.TabIndex = 6
        lblSaldoPendiente.Text = "Saldo pendiente"
        ' 
        ' lblPagado
        ' 
        lblPagado.AutoSize = True
        lblPagado.Location = New Point(403, 164)
        lblPagado.Margin = New Padding(4, 0, 4, 0)
        lblPagado.Name = "lblPagado"
        lblPagado.Size = New Size(72, 25)
        lblPagado.TabIndex = 5
        lblPagado.Text = "Pagado"
        ' 
        ' lblTotalMembresia
        ' 
        lblTotalMembresia.AutoSize = True
        lblTotalMembresia.Location = New Point(393, 98)
        lblTotalMembresia.Margin = New Padding(4, 0, 4, 0)
        lblTotalMembresia.Name = "lblTotalMembresia"
        lblTotalMembresia.Size = New Size(100, 25)
        lblTotalMembresia.TabIndex = 4
        lblTotalMembresia.Text = "membresia"
        ' 
        ' lblEstadoCuenta
        ' 
        lblEstadoCuenta.AutoSize = True
        lblEstadoCuenta.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblEstadoCuenta.Location = New Point(231, 34)
        lblEstadoCuenta.Margin = New Padding(4, 0, 4, 0)
        lblEstadoCuenta.Name = "lblEstadoCuenta"
        lblEstadoCuenta.Size = New Size(174, 21)
        lblEstadoCuenta.TabIndex = 3
        lblEstadoCuenta.Text = "Estado de la cuenta:"
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(lblMiMembresia)
        Panel2.Controls.Add(lblDiasRestantes)
        Panel2.Controls.Add(prgMembresia)
        Panel2.Controls.Add(lblIncluyeClases)
        Panel2.Controls.Add(lblVence)
        Panel2.Controls.Add(lblInicio)
        Panel2.Controls.Add(lblTipoMembresia)
        Panel2.Location = New Point(17, 108)
        Panel2.Margin = New Padding(4, 5, 4, 5)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(602, 312)
        Panel2.TabIndex = 0
        ' 
        ' lblMiMembresia
        ' 
        lblMiMembresia.AutoSize = True
        lblMiMembresia.Font = New Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblMiMembresia.Location = New Point(21, 30)
        lblMiMembresia.Name = "lblMiMembresia"
        lblMiMembresia.Size = New Size(141, 25)
        lblMiMembresia.TabIndex = 6
        lblMiMembresia.Text = "Mi Membresía"
        ' 
        ' lblDiasRestantes
        ' 
        lblDiasRestantes.AutoSize = True
        lblDiasRestantes.Location = New Point(32, 187)
        lblDiasRestantes.Name = "lblDiasRestantes"
        lblDiasRestantes.Size = New Size(126, 25)
        lblDiasRestantes.TabIndex = 5
        lblDiasRestantes.Text = "Días restantes:"
        ' 
        ' prgMembresia
        ' 
        prgMembresia.Location = New Point(32, 217)
        prgMembresia.Margin = New Padding(4, 5, 4, 5)
        prgMembresia.Name = "prgMembresia"
        prgMembresia.Size = New Size(538, 38)
        prgMembresia.TabIndex = 4
        ' 
        ' lblIncluyeClases
        ' 
        lblIncluyeClases.AutoSize = True
        lblIncluyeClases.Location = New Point(452, 72)
        lblIncluyeClases.Margin = New Padding(4, 0, 4, 0)
        lblIncluyeClases.Name = "lblIncluyeClases"
        lblIncluyeClases.Size = New Size(118, 25)
        lblIncluyeClases.TabIndex = 3
        lblIncluyeClases.Text = "Incluye clases"
        ' 
        ' lblVence
        ' 
        lblVence.AutoSize = True
        lblVence.Location = New Point(320, 72)
        lblVence.Margin = New Padding(4, 0, 4, 0)
        lblVence.Name = "lblVence"
        lblVence.Size = New Size(58, 25)
        lblVence.TabIndex = 2
        lblVence.Text = "Vence"
        ' 
        ' lblInicio
        ' 
        lblInicio.AutoSize = True
        lblInicio.Location = New Point(184, 72)
        lblInicio.Margin = New Padding(4, 0, 4, 0)
        lblInicio.Name = "lblInicio"
        lblInicio.Size = New Size(54, 25)
        lblInicio.TabIndex = 1
        lblInicio.Text = "Inicio"
        ' 
        ' lblTipoMembresia
        ' 
        lblTipoMembresia.AutoSize = True
        lblTipoMembresia.Location = New Point(50, 72)
        lblTipoMembresia.Margin = New Padding(4, 0, 4, 0)
        lblTipoMembresia.Name = "lblTipoMembresia"
        lblTipoMembresia.Size = New Size(47, 25)
        lblTipoMembresia.TabIndex = 0
        lblTipoMembresia.Text = "Tipo"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(23, 447)
        Label7.Margin = New Padding(4, 0, 4, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(104, 25)
        Label7.TabIndex = 7
        Label7.Text = "Mis pagos"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(660, 447)
        Label8.Margin = New Padding(4, 0, 4, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(290, 25)
        Label8.TabIndex = 8
        Label8.Text = "Clases disponibles esta semana"
        ' 
        ' dgvPagos
        ' 
        dgvPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPagos.Columns.AddRange(New DataGridViewColumn() {Column1, Column2, Column3, Column4})
        dgvPagos.Location = New Point(17, 480)
        dgvPagos.Margin = New Padding(4, 5, 4, 5)
        dgvPagos.Name = "dgvPagos"
        dgvPagos.RowHeadersWidth = 62
        dgvPagos.Size = New Size(602, 541)
        dgvPagos.TabIndex = 9
        ' 
        ' Column1
        ' 
        Column1.HeaderText = "Fecha"
        Column1.MinimumWidth = 8
        Column1.Name = "Column1"
        Column1.Width = 150
        ' 
        ' Column2
        ' 
        Column2.HeaderText = "Concepto"
        Column2.MinimumWidth = 8
        Column2.Name = "Column2"
        Column2.Width = 150
        ' 
        ' Column3
        ' 
        Column3.HeaderText = "Monto C$"
        Column3.MinimumWidth = 8
        Column3.Name = "Column3"
        Column3.Width = 150
        ' 
        ' Column4
        ' 
        Column4.HeaderText = "Metodo"
        Column4.MinimumWidth = 8
        Column4.Name = "Column4"
        Column4.Width = 150
        ' 
        ' dgvClases
        ' 
        dgvClases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvClases.Columns.AddRange(New DataGridViewColumn() {Column5, Column6, Column7, Column8, Column9})
        dgvClases.Location = New Point(651, 480)
        dgvClases.Margin = New Padding(4, 5, 4, 5)
        dgvClases.Name = "dgvClases"
        dgvClases.RowHeadersWidth = 62
        dgvClases.Size = New Size(1033, 541)
        dgvClases.TabIndex = 10
        ' 
        ' Column5
        ' 
        Column5.HeaderText = "Dia"
        Column5.MinimumWidth = 8
        Column5.Name = "Column5"
        Column5.Width = 150
        ' 
        ' Column6
        ' 
        Column6.HeaderText = "Hora"
        Column6.MinimumWidth = 8
        Column6.Name = "Column6"
        Column6.Width = 150
        ' 
        ' Column7
        ' 
        Column7.HeaderText = "Actividad"
        Column7.MinimumWidth = 8
        Column7.Name = "Column7"
        Column7.Width = 150
        ' 
        ' Column8
        ' 
        Column8.HeaderText = "Instructor"
        Column8.MinimumWidth = 8
        Column8.Name = "Column8"
        Column8.Width = 150
        ' 
        ' Column9
        ' 
        Column9.HeaderText = "Sala"
        Column9.MinimumWidth = 8
        Column9.Name = "Column9"
        Column9.Width = 150
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.ImageScalingSize = New Size(24, 24)
        StatusStrip1.Items.AddRange(New ToolStripItem() {stsUsuario, stsRol, stsModo})
        StatusStrip1.Location = New Point(0, 1128)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Padding = New Padding(1, 0, 20, 0)
        StatusStrip1.Size = New Size(1711, 32)
        StatusStrip1.TabIndex = 11
        StatusStrip1.Text = "StatusStrip1"
        ' 
        ' stsUsuario
        ' 
        stsUsuario.Name = "stsUsuario"
        stsUsuario.Size = New Size(72, 25)
        stsUsuario.Text = "Usuario"
        ' 
        ' stsRol
        ' 
        stsRol.Name = "stsRol"
        stsRol.Size = New Size(37, 25)
        stsRol.Text = "Rol"
        ' 
        ' stsModo
        ' 
        stsModo.Name = "stsModo"
        stsModo.Size = New Size(61, 25)
        stsModo.Text = "Modo"
        ' 
        ' lblNombreSocio
        ' 
        lblNombreSocio.AutoSize = True
        lblNombreSocio.Font = New Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblNombreSocio.Location = New Point(48, 14)
        lblNombreSocio.Name = "lblNombreSocio"
        lblNombreSocio.Size = New Size(111, 25)
        lblNombreSocio.TabIndex = 12
        lblNombreSocio.Text = "Hola, Socio"
        ' 
        ' lblInfoSocio
        ' 
        lblInfoSocio.AutoSize = True
        lblInfoSocio.Location = New Point(49, 36)
        lblInfoSocio.Name = "lblInfoSocio"
        lblInfoSocio.Size = New Size(218, 25)
        lblInfoSocio.TabIndex = 13
        lblInfoSocio.Text = "Socio N.º - Último acceso:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(53, 98)
        Label1.Name = "Label1"
        Label1.Size = New Size(142, 25)
        Label1.TabIndex = 7
        Label1.Text = "Total Membresia"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(53, 164)
        Label2.Name = "Label2"
        Label2.Size = New Size(72, 25)
        Label2.TabIndex = 8
        Label2.Text = "Pagado"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(53, 230)
        Label3.Name = "Label3"
        Label3.Size = New Size(139, 25)
        Label3.TabIndex = 9
        Label3.Text = "Saldo Pendiente"
        ' 
        ' lblEstadoMembresia
        ' 
        lblEstadoMembresia.AutoSize = True
        lblEstadoMembresia.Font = New Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblEstadoMembresia.Location = New Point(53, 30)
        lblEstadoMembresia.Name = "lblEstadoMembresia"
        lblEstadoMembresia.Size = New Size(171, 25)
        lblEstadoMembresia.TabIndex = 10
        lblEstadoMembresia.Text = "Estado de Cuenta:"
        ' 
        ' frmPortalSocio
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1711, 1160)
        Controls.Add(lblInfoSocio)
        Controls.Add(lblNombreSocio)
        Controls.Add(StatusStrip1)
        Controls.Add(dgvClases)
        Controls.Add(dgvPagos)
        Controls.Add(Label7)
        Controls.Add(Label8)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(btnCerrarSesion)
        Controls.Add(btnCambiarContrasena)
        Margin = New Padding(4, 5, 4, 5)
        Name = "frmPortalSocio"
        Text = "Portal de socios ---Mi membresia"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(dgvPagos, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvClases, ComponentModel.ISupportInitialize).EndInit()
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnCambiarContrasena As Button
    Friend WithEvents btnCerrarSesion As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblEstadoCuenta As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents prgMembresia As ProgressBar
    Friend WithEvents lblIncluyeClases As Label
    Friend WithEvents lblVence As Label
    Friend WithEvents lblInicio As Label
    Friend WithEvents lblTipoMembresia As Label
    Friend WithEvents lblSaldoPendiente As Label
    Friend WithEvents lblPagado As Label
    Friend WithEvents lblTotalMembresia As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents dgvPagos As DataGridView
    Friend WithEvents dgvClases As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents stsUsuario As ToolStripStatusLabel
    Friend WithEvents stsRol As ToolStripStatusLabel
    Friend WithEvents stsModo As ToolStripStatusLabel
    Friend WithEvents lblDiasRestantes As Label
    Friend WithEvents lblNombreSocio As Label
    Friend WithEvents lblInfoSocio As Label
    Friend WithEvents lblMiMembresia As Label
    Friend WithEvents lblEstadoMembresia As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
