<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMembresiasPagos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMembresiasPagos))
        btnImprimirRecibo = New Button()
        btnConstancia = New Button()
        chkImprimirAlRegistrar = New CheckBox()
        pdRecibo = New Printing.PrintDocument()
        pdConstancia = New Printing.PrintDocument()
        ppdVista = New PrintPreviewDialog()
        psdPagina = New PageSetupDialog()
        prdImpresora = New PrintDialog()
        btnAnularPago = New Button()
        btnRegistrarPago = New Button()
        lblSocio = New Label()
        txtSocio = New TextBox()
        btnBuscarSocio = New Button()
        grpRegistrarPago = New GroupBox()
        txtSaldo = New TextBox()
        lblSaldo = New Label()
        TextBox1 = New TextBox()
        lblPago = New Label()
        txtTotal = New TextBox()
        lblTotal = New Label()
        grpRegistrarPago.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnImprimirRecibo
        ' 
        btnImprimirRecibo.Enabled = False
        btnImprimirRecibo.Location = New Point(295, 100)
        btnImprimirRecibo.Name = "btnImprimirRecibo"
        btnImprimirRecibo.Size = New Size(125, 39)
        btnImprimirRecibo.TabIndex = 0
        btnImprimirRecibo.Text = "Imprimir recibo"
        btnImprimirRecibo.UseVisualStyleBackColor = True
        ' 
        ' btnConstancia
        ' 
        btnConstancia.Location = New Point(444, 101)
        btnConstancia.Name = "btnConstancia"
        btnConstancia.Size = New Size(98, 37)
        btnConstancia.TabIndex = 1
        btnConstancia.Text = "Constancia"
        btnConstancia.UseVisualStyleBackColor = True
        ' 
        ' chkImprimirAlRegistrar
        ' 
        chkImprimirAlRegistrar.AutoSize = True
        chkImprimirAlRegistrar.Checked = True
        chkImprimirAlRegistrar.CheckState = CheckState.Checked
        chkImprimirAlRegistrar.Location = New Point(565, 111)
        chkImprimirAlRegistrar.Name = "chkImprimirAlRegistrar"
        chkImprimirAlRegistrar.Size = New Size(194, 21)
        chkImprimirAlRegistrar.TabIndex = 2
        chkImprimirAlRegistrar.Text = "Imprimir recibo al registrar"
        chkImprimirAlRegistrar.UseVisualStyleBackColor = True
        ' 
        ' pdRecibo
        ' 
        pdRecibo.DocumentName = "Recibo GymControl"
        ' 
        ' pdConstancia
        ' 
        pdConstancia.DocumentName = "Constancia de membresía"
        ' 
        ' ppdVista
        ' 
        ppdVista.AutoScrollMargin = New Size(0, 0)
        ppdVista.AutoScrollMinSize = New Size(0, 0)
        ppdVista.ClientSize = New Size(400, 300)
        ppdVista.Enabled = True
        ppdVista.Icon = CType(resources.GetObject("ppdVista.Icon"), Icon)
        ppdVista.Name = "ppdVista"
        ppdVista.ShowIcon = False
        ppdVista.UseAntiAlias = True
        ppdVista.Visible = False
        ' 
        ' psdPagina
        ' 
        psdPagina.Document = pdConstancia
        psdPagina.EnableMetric = True
        ' 
        ' prdImpresora
        ' 
        prdImpresora.UseEXDialog = True
        ' 
        ' btnAnularPago
        ' 
        btnAnularPago.BackColor = Color.Red
        btnAnularPago.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold)
        btnAnularPago.ForeColor = Color.White
        btnAnularPago.Location = New Point(153, 99)
        btnAnularPago.Name = "btnAnularPago"
        btnAnularPago.Size = New Size(112, 39)
        btnAnularPago.TabIndex = 4
        btnAnularPago.Text = "Anular Pago"
        btnAnularPago.UseVisualStyleBackColor = False
        ' 
        ' btnRegistrarPago
        ' 
        btnRegistrarPago.BackColor = Color.Blue
        btnRegistrarPago.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold)
        btnRegistrarPago.ForeColor = Color.White
        btnRegistrarPago.Location = New Point(7, 101)
        btnRegistrarPago.Name = "btnRegistrarPago"
        btnRegistrarPago.Size = New Size(121, 37)
        btnRegistrarPago.TabIndex = 5
        btnRegistrarPago.Text = "Registrar Pago"
        btnRegistrarPago.UseVisualStyleBackColor = False
        ' 
        ' lblSocio
        ' 
        lblSocio.AutoSize = True
        lblSocio.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSocio.Location = New Point(29, 20)
        lblSocio.Name = "lblSocio"
        lblSocio.Size = New Size(60, 21)
        lblSocio.TabIndex = 6
        lblSocio.Text = "Socio: "
        ' 
        ' txtSocio
        ' 
        txtSocio.Location = New Point(108, 20)
        txtSocio.Name = "txtSocio"
        txtSocio.Size = New Size(169, 23)
        txtSocio.TabIndex = 7
        ' 
        ' btnBuscarSocio
        ' 
        btnBuscarSocio.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnBuscarSocio.Location = New Point(307, 20)
        btnBuscarSocio.Name = "btnBuscarSocio"
        btnBuscarSocio.Size = New Size(131, 31)
        btnBuscarSocio.TabIndex = 8
        btnBuscarSocio.Text = "Buscar Socio"
        btnBuscarSocio.UseVisualStyleBackColor = True
        ' 
        ' grpRegistrarPago
        ' 
        grpRegistrarPago.Controls.Add(txtSaldo)
        grpRegistrarPago.Controls.Add(lblSaldo)
        grpRegistrarPago.Controls.Add(TextBox1)
        grpRegistrarPago.Controls.Add(lblPago)
        grpRegistrarPago.Controls.Add(chkImprimirAlRegistrar)
        grpRegistrarPago.Controls.Add(btnAnularPago)
        grpRegistrarPago.Controls.Add(btnConstancia)
        grpRegistrarPago.Controls.Add(btnRegistrarPago)
        grpRegistrarPago.Controls.Add(btnImprimirRecibo)
        grpRegistrarPago.Controls.Add(txtTotal)
        grpRegistrarPago.Controls.Add(lblTotal)
        grpRegistrarPago.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpRegistrarPago.Location = New Point(12, 74)
        grpRegistrarPago.Name = "grpRegistrarPago"
        grpRegistrarPago.Size = New Size(759, 158)
        grpRegistrarPago.TabIndex = 10
        grpRegistrarPago.TabStop = False
        grpRegistrarPago.Text = "Registrar Pago"
        ' 
        ' txtSaldo
        ' 
        txtSaldo.Location = New Point(508, 29)
        txtSaldo.Name = "txtSaldo"
        txtSaldo.ReadOnly = True
        txtSaldo.Size = New Size(161, 25)
        txtSaldo.TabIndex = 5
        ' 
        ' lblSaldo
        ' 
        lblSaldo.AutoSize = True
        lblSaldo.Font = New Font("Segoe UI Semibold", 10F, FontStyle.Bold)
        lblSaldo.Location = New Point(444, 36)
        lblSaldo.Name = "lblSaldo"
        lblSaldo.Size = New Size(44, 19)
        lblSaldo.TabIndex = 4
        lblSaldo.Text = "Saldo"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(267, 31)
        TextBox1.Name = "TextBox1"
        TextBox1.ReadOnly = True
        TextBox1.Size = New Size(144, 25)
        TextBox1.TabIndex = 3
        ' 
        ' lblPago
        ' 
        lblPago.AutoSize = True
        lblPago.Font = New Font("Segoe UI Semibold", 10F, FontStyle.Bold)
        lblPago.Location = New Point(197, 34)
        lblPago.Name = "lblPago"
        lblPago.Size = New Size(55, 19)
        lblPago.TabIndex = 2
        lblPago.Text = "Pagado"
        ' 
        ' txtTotal
        ' 
        txtTotal.Location = New Point(56, 29)
        txtTotal.Name = "txtTotal"
        txtTotal.ReadOnly = True
        txtTotal.Size = New Size(127, 25)
        txtTotal.TabIndex = 1
        ' 
        ' lblTotal
        ' 
        lblTotal.AutoSize = True
        lblTotal.Font = New Font("Segoe UI Semibold", 10F, FontStyle.Bold)
        lblTotal.Location = New Point(17, 34)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(40, 19)
        lblTotal.TabIndex = 0
        lblTotal.Text = "Total"
        ' 
        ' frmMembresiasPagos
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 250)
        Controls.Add(grpRegistrarPago)
        Controls.Add(btnBuscarSocio)
        Controls.Add(txtSocio)
        Controls.Add(lblSocio)
        Name = "frmMembresiasPagos"
        Text = "frmMembresiasPagos"
        grpRegistrarPago.ResumeLayout(False)
        grpRegistrarPago.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnImprimirRecibo As Button
    Friend WithEvents btnConstancia As Button
    Friend WithEvents chkImprimirAlRegistrar As CheckBox
    Friend WithEvents pdRecibo As Printing.PrintDocument
    Friend WithEvents pdConstancia As Printing.PrintDocument
    Friend WithEvents ppdVista As PrintPreviewDialog
    Friend WithEvents psdPagina As PageSetupDialog
    Friend WithEvents prdImpresora As PrintDialog
    Friend WithEvents btnAnularPago As Button
    Friend WithEvents btnRegistrarPago As Button
    Friend WithEvents lblSocio As Label
    Friend WithEvents txtSocio As TextBox
    Friend WithEvents btnBuscarSocio As Button
    Friend WithEvents grpRegistrarPago As GroupBox
    Friend WithEvents txtSaldo As TextBox
    Friend WithEvents lblSaldo As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents lblPago As Label
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents lblTotal As Label
End Class
