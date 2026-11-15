<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        txtUsuario = New TextBox()
        StatusStrip1 = New StatusStrip()
        stsConexion = New ToolStripStatusLabel()
        ToolStripStatusLabel2 = New ToolStripStatusLabel()
        ToolStripStatusLabel1 = New ToolStripStatusLabel()
        txtContraseña = New TextBox()
        chkMostrar = New CheckBox()
        ibllmensaje = New Label()
        iblMensaje = New Label()
        lblMensaje = New Label()
        btnIngresar = New Button()
        btnSalir = New Button()
        iblOlvido = New Label()
        StatusStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtUsuario
        ' 
        txtUsuario.Location = New Point(33, 44)
        txtUsuario.Name = "txtUsuario"
        txtUsuario.Size = New Size(470, 23)
        txtUsuario.TabIndex = 0
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.ImageScalingSize = New Size(24, 24)
        StatusStrip1.Items.AddRange(New ToolStripItem() {stsConexion, ToolStripStatusLabel2, ToolStripStatusLabel1})
        StatusStrip1.Location = New Point(0, 339)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Size = New Size(545, 22)
        StatusStrip1.TabIndex = 1
        StatusStrip1.Text = "StatusStrip1"
        ' 
        ' stsConexion
        ' 
        stsConexion.Name = "stsConexion"
        stsConexion.Size = New Size(131, 17)
        stsConexion.Text = "Servidor: localhost:3306"
        ' 
        ' ToolStripStatusLabel2
        ' 
        ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        ToolStripStatusLabel2.Size = New Size(96, 17)
        ToolStripStatusLabel2.Text = "BD: gimnasio_db"
        ' 
        ' ToolStripStatusLabel1
        ' 
        ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        ToolStripStatusLabel1.Size = New Size(29, 17)
        ToolStripStatusLabel1.Text = "v1.o"
        ' 
        ' txtContraseña
        ' 
        txtContraseña.Location = New Point(33, 115)
        txtContraseña.Name = "txtContraseña"
        txtContraseña.Size = New Size(470, 23)
        txtContraseña.TabIndex = 2
        txtContraseña.UseSystemPasswordChar = True
        ' 
        ' chkMostrar
        ' 
        chkMostrar.AutoSize = True
        chkMostrar.Location = New Point(32, 140)
        chkMostrar.Name = "chkMostrar"
        chkMostrar.Size = New Size(128, 19)
        chkMostrar.TabIndex = 3
        chkMostrar.Text = "Mostrar contraseña"
        chkMostrar.UseVisualStyleBackColor = True
        ' 
        ' ibllmensaje
        ' 
        ibllmensaje.AutoSize = True
        ibllmensaje.Location = New Point(32, 19)
        ibllmensaje.Name = "ibllmensaje"
        ibllmensaje.Size = New Size(47, 15)
        ibllmensaje.TabIndex = 4
        ibllmensaje.Text = "Usuario"
        ' 
        ' iblMensaje
        ' 
        iblMensaje.AutoSize = True
        iblMensaje.Location = New Point(32, 85)
        iblMensaje.Name = "iblMensaje"
        iblMensaje.Size = New Size(67, 15)
        iblMensaje.TabIndex = 5
        iblMensaje.Text = "Contraseña"
        ' 
        ' lblMensaje
        ' 
        lblMensaje.AutoSize = True
        lblMensaje.Location = New Point(122, 201)
        lblMensaje.Name = "lblMensaje"
        lblMensaje.Size = New Size(287, 15)
        lblMensaje.TabIndex = 6
        lblMensaje.Text = "Uusario o contraseña incorrecos. Intentos restantes: 2"
        lblMensaje.Visible = False
        ' 
        ' btnIngresar
        ' 
        btnIngresar.Location = New Point(33, 238)
        btnIngresar.Name = "btnIngresar"
        btnIngresar.Size = New Size(470, 23)
        btnIngresar.TabIndex = 7
        btnIngresar.Text = "Iniciar sesion"
        btnIngresar.UseVisualStyleBackColor = True
        ' 
        ' btnSalir
        ' 
        btnSalir.Location = New Point(32, 274)
        btnSalir.Name = "btnSalir"
        btnSalir.Size = New Size(470, 23)
        btnSalir.TabIndex = 8
        btnSalir.Text = "Salir"
        btnSalir.UseVisualStyleBackColor = True
        ' 
        ' iblOlvido
        ' 
        iblOlvido.AutoSize = True
        iblOlvido.Location = New Point(86, 306)
        iblOlvido.Name = "iblOlvido"
        iblOlvido.Size = New Size(356, 15)
        iblOlvido.TabIndex = 9
        iblOlvido.Text = "Olvido su contraseña? Solicite el restablecimiento al administrador"
        ' 
        ' frmLogin
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(545, 361)
        Controls.Add(iblOlvido)
        Controls.Add(btnSalir)
        Controls.Add(btnIngresar)
        Controls.Add(lblMensaje)
        Controls.Add(iblMensaje)
        Controls.Add(ibllmensaje)
        Controls.Add(chkMostrar)
        Controls.Add(txtContraseña)
        Controls.Add(StatusStrip1)
        Controls.Add(txtUsuario)
        Name = "frmLogin"
        Text = "Iniciar sesion ----- GymControl"
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents stsConexion As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents txtContraseña As TextBox
    Friend WithEvents chkMostrar As CheckBox
    Friend WithEvents ibllmensaje As Label
    Friend WithEvents iblMensaje As Label
    Friend WithEvents lblMensaje As Label
    Friend WithEvents btnIngresar As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents iblOlvido As Label
End Class
