<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVisorReportes
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
        pnlParametros = New Panel()
        btnGenerar = New Button()
        lblCargando = New Label()
        lblSocio = New Label()
        txtSocio = New TextBox()
        lblDesde = New Label()
        txtFecha = New TextBox()
        pnlParametros.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlParametros
        ' 
        pnlParametros.Controls.Add(txtFecha)
        pnlParametros.Controls.Add(lblDesde)
        pnlParametros.Controls.Add(txtSocio)
        pnlParametros.Controls.Add(lblSocio)
        pnlParametros.Controls.Add(lblCargando)
        pnlParametros.Controls.Add(btnGenerar)
        pnlParametros.Dock = DockStyle.Top
        pnlParametros.Location = New Point(0, 0)
        pnlParametros.Name = "pnlParametros"
        pnlParametros.Size = New Size(702, 71)
        pnlParametros.TabIndex = 0
        ' 
        ' btnGenerar
        ' 
        btnGenerar.BackColor = Color.Blue
        btnGenerar.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnGenerar.ForeColor = Color.White
        btnGenerar.Location = New Point(445, 26)
        btnGenerar.Name = "btnGenerar"
        btnGenerar.Size = New Size(114, 34)
        btnGenerar.TabIndex = 0
        btnGenerar.Text = "Generar"
        btnGenerar.UseVisualStyleBackColor = False
        ' 
        ' lblCargando
        ' 
        lblCargando.AutoSize = True
        lblCargando.Location = New Point(583, 37)
        lblCargando.Name = "lblCargando"
        lblCargando.Size = New Size(100, 15)
        lblCargando.TabIndex = 1
        lblCargando.Text = "Cargando datos…"
        lblCargando.Visible = False
        ' 
        ' lblSocio
        ' 
        lblSocio.AutoSize = True
        lblSocio.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSocio.Location = New Point(12, 26)
        lblSocio.Name = "lblSocio"
        lblSocio.Size = New Size(52, 21)
        lblSocio.TabIndex = 2
        lblSocio.Text = "Socio"
        ' 
        ' txtSocio
        ' 
        txtSocio.Location = New Point(71, 27)
        txtSocio.Name = "txtSocio"
        txtSocio.Size = New Size(100, 23)
        txtSocio.TabIndex = 3
        ' 
        ' lblDesde
        ' 
        lblDesde.AutoSize = True
        lblDesde.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDesde.Location = New Point(206, 30)
        lblDesde.Name = "lblDesde"
        lblDesde.Size = New Size(52, 20)
        lblDesde.TabIndex = 4
        lblDesde.Text = "Desde"
        ' 
        ' txtFecha
        ' 
        txtFecha.Location = New Point(303, 29)
        txtFecha.Name = "txtFecha"
        txtFecha.Size = New Size(100, 23)
        txtFecha.TabIndex = 5
        ' 
        ' frmVisorReportes
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(702, 374)
        Controls.Add(pnlParametros)
        Name = "frmVisorReportes"
        Text = " "
        WindowState = FormWindowState.Maximized
        pnlParametros.ResumeLayout(False)
        pnlParametros.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlParametros As Panel
    Friend WithEvents btnGenerar As Button
    Friend WithEvents lblSocio As Label
    Friend WithEvents lblCargando As Label
    Friend WithEvents txtFecha As TextBox
    Friend WithEvents lblDesde As Label
    Friend WithEvents txtSocio As TextBox
End Class
