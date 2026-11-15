<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPrincipal
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
        MenuStrip2 = New MenuStrip()
        mnuPrincipal = New ToolStripMenuItem()
        mnuSocios = New ToolStripMenuItem()
        mnuMembresias = New ToolStripMenuItem()
        mnuPagos = New ToolStripMenuItem()
        InstruccionesToolStripMenuItem = New ToolStripMenuItem()
        HorariosToolStripMenuItem = New ToolStripMenuItem()
        ReToolStripMenuItem = New ToolStripMenuItem()
        SeguridadToolStripMenuItem = New ToolStripMenuItem()
        AyudaToolStripMenuItem = New ToolStripMenuItem()
        pnlNavegacion = New Panel()
        Button10 = New Button()
        Button9 = New Button()
        Button8 = New Button()
        Button7 = New Button()
        Button6 = New Button()
        Button5 = New Button()
        Button4 = New Button()
        Button3 = New Button()
        Button2 = New Button()
        Button1 = New Button()
        pnlIndicadores = New Panel()
        Panel1 = New Panel()
        Panel2 = New Panel()
        Panel3 = New Panel()
        Button11 = New Button()
        Button12 = New Button()
        Button13 = New Button()
        Button14 = New Button()
        StatusStrip1 = New StatusStrip()
        ToolStripStatusLabel1 = New ToolStripStatusLabel()
        ToolStripStatusLabel2 = New ToolStripStatusLabel()
        ToolStripStatusLabel3 = New ToolStripStatusLabel()
        ToolStripStatusLabel4 = New ToolStripStatusLabel()
        dgvPorVencer = New DataGridView()
        dgvClasesHoy = New DataGridView()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        btnReportes = New Button()
        MenuStrip2.SuspendLayout()
        pnlNavegacion.SuspendLayout()
        StatusStrip1.SuspendLayout()
        CType(dgvPorVencer, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvClasesHoy, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' MenuStrip2
        ' 
        MenuStrip2.ImageScalingSize = New Size(24, 24)
        MenuStrip2.Items.AddRange(New ToolStripItem() {mnuPrincipal, mnuSocios, mnuMembresias, mnuPagos, InstruccionesToolStripMenuItem, HorariosToolStripMenuItem, ReToolStripMenuItem, SeguridadToolStripMenuItem, AyudaToolStripMenuItem})
        MenuStrip2.Location = New Point(0, 0)
        MenuStrip2.Name = "MenuStrip2"
        MenuStrip2.Padding = New Padding(9, 3, 0, 3)
        MenuStrip2.Size = New Size(1621, 35)
        MenuStrip2.TabIndex = 1
        MenuStrip2.Text = "MenuStrip2"
        ' 
        ' mnuPrincipal
        ' 
        mnuPrincipal.Name = "mnuPrincipal"
        mnuPrincipal.Size = New Size(88, 29)
        mnuPrincipal.Text = "Archivo"
        ' 
        ' mnuSocios
        ' 
        mnuSocios.Name = "mnuSocios"
        mnuSocios.Size = New Size(80, 29)
        mnuSocios.Text = "Socios"
        ' 
        ' mnuMembresias
        ' 
        mnuMembresias.Name = "mnuMembresias"
        mnuMembresias.Size = New Size(124, 29)
        mnuMembresias.Text = "Membresias"
        ' 
        ' mnuPagos
        ' 
        mnuPagos.Name = "mnuPagos"
        mnuPagos.Size = New Size(76, 29)
        mnuPagos.Text = "Pagos"
        ' 
        ' InstruccionesToolStripMenuItem
        ' 
        InstruccionesToolStripMenuItem.Name = "InstruccionesToolStripMenuItem"
        InstruccionesToolStripMenuItem.Size = New Size(121, 29)
        InstruccionesToolStripMenuItem.Text = "Instructores"
        ' 
        ' HorariosToolStripMenuItem
        ' 
        HorariosToolStripMenuItem.Name = "HorariosToolStripMenuItem"
        HorariosToolStripMenuItem.Size = New Size(96, 29)
        HorariosToolStripMenuItem.Text = "Horarios"
        ' 
        ' ReToolStripMenuItem
        ' 
        ReToolStripMenuItem.Name = "ReToolStripMenuItem"
        ReToolStripMenuItem.Size = New Size(98, 29)
        ReToolStripMenuItem.Text = "Reportes"
        ' 
        ' SeguridadToolStripMenuItem
        ' 
        SeguridadToolStripMenuItem.Name = "SeguridadToolStripMenuItem"
        SeguridadToolStripMenuItem.Size = New Size(109, 29)
        SeguridadToolStripMenuItem.Text = "Seguridad"
        ' 
        ' AyudaToolStripMenuItem
        ' 
        AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem"
        AyudaToolStripMenuItem.Size = New Size(79, 29)
        AyudaToolStripMenuItem.Text = "Ayuda"
        ' 
        ' pnlNavegacion
        ' 
        pnlNavegacion.BackColor = SystemColors.HighlightText
        pnlNavegacion.Controls.Add(btnReportes)
        pnlNavegacion.Controls.Add(Button10)
        pnlNavegacion.Controls.Add(Button9)
        pnlNavegacion.Controls.Add(Button8)
        pnlNavegacion.Controls.Add(Button7)
        pnlNavegacion.Controls.Add(Button6)
        pnlNavegacion.Controls.Add(Button5)
        pnlNavegacion.Controls.Add(Button4)
        pnlNavegacion.Controls.Add(Button3)
        pnlNavegacion.Controls.Add(Button2)
        pnlNavegacion.Controls.Add(Button1)
        pnlNavegacion.Location = New Point(0, 45)
        pnlNavegacion.Margin = New Padding(4, 5, 4, 5)
        pnlNavegacion.Name = "pnlNavegacion"
        pnlNavegacion.Size = New Size(286, 1013)
        pnlNavegacion.TabIndex = 2
        ' 
        ' Button10
        ' 
        Button10.BackColor = Color.LightCoral
        Button10.ForeColor = SystemColors.ActiveCaptionText
        Button10.Location = New Point(44, 950)
        Button10.Margin = New Padding(4, 5, 4, 5)
        Button10.Name = "Button10"
        Button10.Size = New Size(186, 38)
        Button10.TabIndex = 9
        Button10.Text = "Cerrar sesion"
        Button10.UseVisualStyleBackColor = False
        ' 
        ' Button9
        ' 
        Button9.Location = New Point(44, 428)
        Button9.Margin = New Padding(4, 5, 4, 5)
        Button9.Name = "Button9"
        Button9.Size = New Size(186, 38)
        Button9.TabIndex = 8
        Button9.Text = "Bitacora de accesos"
        Button9.UseVisualStyleBackColor = True
        ' 
        ' Button8
        ' 
        Button8.Location = New Point(44, 380)
        Button8.Margin = New Padding(4, 5, 4, 5)
        Button8.Name = "Button8"
        Button8.Size = New Size(186, 38)
        Button8.TabIndex = 7
        Button8.Text = "Usuarios y roles"
        Button8.UseVisualStyleBackColor = True
        ' 
        ' Button7
        ' 
        Button7.Location = New Point(44, 294)
        Button7.Margin = New Padding(4, 5, 4, 5)
        Button7.Name = "Button7"
        Button7.Size = New Size(186, 38)
        Button7.TabIndex = 6
        Button7.Text = "Horarios"
        Button7.UseVisualStyleBackColor = True
        ' 
        ' Button6
        ' 
        Button6.Location = New Point(44, 246)
        Button6.Margin = New Padding(4, 5, 4, 5)
        Button6.Name = "Button6"
        Button6.Size = New Size(186, 38)
        Button6.TabIndex = 5
        Button6.Text = "Actividades y salas"
        Button6.UseVisualStyleBackColor = True
        ' 
        ' Button5
        ' 
        Button5.Location = New Point(44, 198)
        Button5.Margin = New Padding(4, 5, 4, 5)
        Button5.Name = "Button5"
        Button5.Size = New Size(186, 38)
        Button5.TabIndex = 4
        Button5.Text = "Instructores"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Location = New Point(44, 150)
        Button4.Margin = New Padding(4, 5, 4, 5)
        Button4.Name = "Button4"
        Button4.Size = New Size(186, 38)
        Button4.TabIndex = 3
        Button4.Text = "Pagos"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(44, 102)
        Button3.Margin = New Padding(4, 5, 4, 5)
        Button3.Name = "Button3"
        Button3.Size = New Size(186, 38)
        Button3.TabIndex = 2
        Button3.Text = "Membresias"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(44, 53)
        Button2.Margin = New Padding(4, 5, 4, 5)
        Button2.Name = "Button2"
        Button2.Size = New Size(186, 38)
        Button2.TabIndex = 1
        Button2.Text = "Socios"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(44, 5)
        Button1.Margin = New Padding(4, 5, 4, 5)
        Button1.Name = "Button1"
        Button1.Size = New Size(186, 38)
        Button1.TabIndex = 0
        Button1.Text = "Inicio"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' pnlIndicadores
        ' 
        pnlIndicadores.Location = New Point(340, 107)
        pnlIndicadores.Margin = New Padding(4, 5, 4, 5)
        pnlIndicadores.Name = "pnlIndicadores"
        pnlIndicadores.Size = New Size(257, 174)
        pnlIndicadores.TabIndex = 10
        ' 
        ' Panel1
        ' 
        Panel1.Location = New Point(1214, 107)
        Panel1.Margin = New Padding(4, 5, 4, 5)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(251, 169)
        Panel1.TabIndex = 11
        ' 
        ' Panel2
        ' 
        Panel2.Location = New Point(635, 107)
        Panel2.Margin = New Padding(4, 5, 4, 5)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(251, 174)
        Panel2.TabIndex = 0
        ' 
        ' Panel3
        ' 
        Panel3.Location = New Point(925, 107)
        Panel3.Margin = New Padding(4, 5, 4, 5)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(251, 174)
        Panel3.TabIndex = 0
        ' 
        ' Button11
        ' 
        Button11.BackColor = SystemColors.GradientActiveCaption
        Button11.Location = New Point(312, 995)
        Button11.Margin = New Padding(4, 5, 4, 5)
        Button11.Name = "Button11"
        Button11.Size = New Size(167, 38)
        Button11.TabIndex = 13
        Button11.Text = "Nuevo socio"
        Button11.UseVisualStyleBackColor = False
        ' 
        ' Button12
        ' 
        Button12.Location = New Point(487, 995)
        Button12.Margin = New Padding(4, 5, 4, 5)
        Button12.Name = "Button12"
        Button12.Size = New Size(136, 38)
        Button12.TabIndex = 14
        Button12.Text = "Registrar pago"
        Button12.UseVisualStyleBackColor = True
        ' 
        ' Button13
        ' 
        Button13.Location = New Point(635, 995)
        Button13.Margin = New Padding(4, 5, 4, 5)
        Button13.Name = "Button13"
        Button13.Size = New Size(183, 38)
        Button13.TabIndex = 15
        Button13.Text = "Renovar membresia"
        Button13.UseVisualStyleBackColor = True
        ' 
        ' Button14
        ' 
        Button14.Location = New Point(826, 995)
        Button14.Margin = New Padding(4, 5, 4, 5)
        Button14.Name = "Button14"
        Button14.Size = New Size(183, 38)
        Button14.TabIndex = 16
        Button14.Text = "Ver horarios"
        Button14.UseVisualStyleBackColor = True
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.ImageScalingSize = New Size(24, 24)
        StatusStrip1.Items.AddRange(New ToolStripItem() {ToolStripStatusLabel1, ToolStripStatusLabel2, ToolStripStatusLabel3, ToolStripStatusLabel4})
        StatusStrip1.Location = New Point(0, 1085)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Padding = New Padding(1, 0, 20, 0)
        StatusStrip1.Size = New Size(1621, 32)
        StatusStrip1.TabIndex = 17
        StatusStrip1.Text = "StatusStrip1"
        ' 
        ' ToolStripStatusLabel1
        ' 
        ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        ToolStripStatusLabel1.Size = New Size(139, 25)
        ToolStripStatusLabel1.Text = "Usuarios: admin"
        ' 
        ' ToolStripStatusLabel2
        ' 
        ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        ToolStripStatusLabel2.Size = New Size(156, 25)
        ToolStripStatusLabel2.Text = "rol: Administrador"
        ' 
        ' ToolStripStatusLabel3
        ' 
        ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        ToolStripStatusLabel3.Size = New Size(340, 25)
        ToolStripStatusLabel3.Text = "Conectado a gimnasio_db localhost 3306"
        ' 
        ' ToolStripStatusLabel4
        ' 
        ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        ToolStripStatusLabel4.Size = New Size(97, 25)
        ToolStripStatusLabel4.Text = "fecha/hora"
        ' 
        ' dgvPorVencer
        ' 
        dgvPorVencer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPorVencer.Location = New Point(312, 435)
        dgvPorVencer.Margin = New Padding(4, 5, 4, 5)
        dgvPorVencer.Name = "dgvPorVencer"
        dgvPorVencer.RowHeadersWidth = 62
        dgvPorVencer.Size = New Size(637, 484)
        dgvPorVencer.TabIndex = 18
        ' 
        ' dgvClasesHoy
        ' 
        dgvClasesHoy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvClasesHoy.Location = New Point(968, 435)
        dgvClasesHoy.Name = "dgvClasesHoy"
        dgvClasesHoy.RowHeadersWidth = 62
        dgvClasesHoy.Size = New Size(580, 484)
        dgvClasesHoy.TabIndex = 19
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(215, 27)
        Label1.Name = "Label1"
        Label1.Size = New Size(93, 15)
        Label1.TabIndex = 20
        Label1.Text = "Panel de control"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(215, 356)
        Label2.Name = "Label2"
        Label2.Size = New Size(41, 15)
        Label2.TabIndex = 21
        Label2.Text = "Label2"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(215, 175)
        Label3.Name = "Label3"
        Label3.Size = New Size(169, 15)
        Label3.TabIndex = 22
        Label3.Text = "Membresias proximas a vencer"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(625, 175)
        Label4.Name = "Label4"
        Label4.Size = New Size(41, 15)
        Label4.TabIndex = 23
        Label4.Text = "Label4"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(312, 63)
        Label5.Name = "Label5"
        Label5.Size = New Size(159, 25)
        Label5.TabIndex = 20
        Label5.Text = "Panel de Control"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(330, 394)
        Label6.Name = "Label6"
        Label6.Size = New Size(278, 25)
        Label6.TabIndex = 21
        Label6.Text = "Membresías próximas a vecer"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(983, 394)
        Label7.Name = "Label7"
        Label7.Size = New Size(131, 25)
        Label7.TabIndex = 22
        Label7.Text = "Clases de hoy"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(330, 965)
        Label8.Name = "Label8"
        Label8.Size = New Size(160, 25)
        Label8.TabIndex = 23
        Label8.Text = "Accesos Rápidos"
        ' 
        ' btnReportes
        ' 
        btnReportes.Location = New Point(44, 340)
        btnReportes.Name = "btnReportes"
        btnReportes.Size = New Size(186, 34)
        btnReportes.TabIndex = 10
        btnReportes.Text = "Reportes"
        btnReportes.UseVisualStyleBackColor = True
        ' 
        ' frmPrincipal
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1621, 1117)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(dgvClasesHoy)
        Controls.Add(dgvPorVencer)
        Controls.Add(StatusStrip1)
        Controls.Add(Button14)
        Controls.Add(Button13)
        Controls.Add(Button12)
        Controls.Add(Button11)
        Controls.Add(Panel2)
        Controls.Add(Panel3)
        Controls.Add(Panel1)
        Controls.Add(pnlIndicadores)
        Controls.Add(pnlNavegacion)
        Controls.Add(MenuStrip2)
        Margin = New Padding(4, 5, 4, 5)
        Name = "frmPrincipal"
        Text = "frmPrincipal"
        MenuStrip2.ResumeLayout(False)
        MenuStrip2.PerformLayout()
        pnlNavegacion.ResumeLayout(False)
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        CType(dgvPorVencer, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvClasesHoy, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents mnuPrincipal As ToolStripMenuItem
    Friend WithEvents mnuSocios As ToolStripMenuItem
    Friend WithEvents mnuMembresias As ToolStripMenuItem
    Friend WithEvents mnuPagos As ToolStripMenuItem
    Friend WithEvents InstruccionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HorariosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SeguridadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents pnlNavegacion As Panel
    Friend WithEvents Button8 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents pnlIndicadores As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Button11 As Button
    Friend WithEvents Button12 As Button
    Friend WithEvents Button13 As Button
    Friend WithEvents Button14 As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents dgvPorVencer As DataGridView
    Friend WithEvents dgvClasesHoy As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents btnReportes As Button
End Class
