<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListadoVencimientos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListadoVencimientos))
        nudDiasAdelante = New NumericUpDown()
        nudDiasAtras = New NumericUpDown()
        chkSoloConSaldo = New CheckBox()
        chkHorizontal = New CheckBox()
        btnCargar = New Button()
        grpFiltros = New GroupBox()
        lblDias = New Label()
        lblDiasVencidos = New Label()
        lblvencimiento = New Label()
        dgvVencimientos = New DataGridView()
        MySqlCommandBuilder1 = New MySqlConnector.MySqlCommandBuilder()
        btnConfigurarPágina = New Button()
        btnVistaPrevia = New Button()
        btnImprimir = New Button()
        lblResumen = New Label()
        pdListado = New Printing.PrintDocument()
        ppdListado = New PrintPreviewDialog()
        psdListado = New PageSetupDialog()
        prdListado = New PrintDialog()
        CType(nudDiasAdelante, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudDiasAtras, ComponentModel.ISupportInitialize).BeginInit()
        grpFiltros.SuspendLayout()
        CType(dgvVencimientos, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' nudDiasAdelante
        ' 
        nudDiasAdelante.Location = New Point(346, 42)
        nudDiasAdelante.Margin = New Padding(4, 5, 4, 5)
        nudDiasAdelante.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        nudDiasAdelante.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudDiasAdelante.Name = "nudDiasAdelante"
        nudDiasAdelante.Size = New Size(77, 39)
        nudDiasAdelante.TabIndex = 0
        nudDiasAdelante.Value = New Decimal(New Integer() {7, 0, 0, 0})
        ' 
        ' nudDiasAtras
        ' 
        nudDiasAtras.Location = New Point(734, 40)
        nudDiasAtras.Margin = New Padding(4, 5, 4, 5)
        nudDiasAtras.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        nudDiasAtras.Name = "nudDiasAtras"
        nudDiasAtras.Size = New Size(97, 39)
        nudDiasAtras.TabIndex = 1
        nudDiasAtras.Value = New Decimal(New Integer() {15, 0, 0, 0})
        ' 
        ' chkSoloConSaldo
        ' 
        chkSoloConSaldo.AutoSize = True
        chkSoloConSaldo.Location = New Point(919, 43)
        chkSoloConSaldo.Margin = New Padding(4, 5, 4, 5)
        chkSoloConSaldo.Name = "chkSoloConSaldo"
        chkSoloConSaldo.Size = New Size(207, 36)
        chkSoloConSaldo.TabIndex = 2
        chkSoloConSaldo.Text = "Solo con saldo"
        chkSoloConSaldo.UseVisualStyleBackColor = True
        ' 
        ' chkHorizontal
        ' 
        chkHorizontal.AutoSize = True
        chkHorizontal.Location = New Point(1151, 43)
        chkHorizontal.Margin = New Padding(4, 5, 4, 5)
        chkHorizontal.Name = "chkHorizontal"
        chkHorizontal.Size = New Size(217, 36)
        chkHorizontal.TabIndex = 3
        chkHorizontal.Text = "Hoja horizontal"
        chkHorizontal.UseVisualStyleBackColor = True
        ' 
        ' btnCargar
        ' 
        btnCargar.BackColor = Color.Blue
        btnCargar.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCargar.ForeColor = Color.White
        btnCargar.Location = New Point(24, 120)
        btnCargar.Margin = New Padding(4, 5, 4, 5)
        btnCargar.Name = "btnCargar"
        btnCargar.Size = New Size(107, 60)
        btnCargar.TabIndex = 4
        btnCargar.Text = "Cargar"
        btnCargar.UseVisualStyleBackColor = False
        ' 
        ' grpFiltros
        ' 
        grpFiltros.Controls.Add(lblDias)
        grpFiltros.Controls.Add(lblDiasVencidos)
        grpFiltros.Controls.Add(lblvencimiento)
        grpFiltros.Controls.Add(nudDiasAtras)
        grpFiltros.Controls.Add(btnCargar)
        grpFiltros.Controls.Add(nudDiasAdelante)
        grpFiltros.Controls.Add(chkSoloConSaldo)
        grpFiltros.Controls.Add(chkHorizontal)
        grpFiltros.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpFiltros.Location = New Point(17, 20)
        grpFiltros.Margin = New Padding(4, 5, 4, 5)
        grpFiltros.Name = "grpFiltros"
        grpFiltros.Padding = New Padding(4, 5, 4, 5)
        grpFiltros.Size = New Size(1505, 190)
        grpFiltros.TabIndex = 5
        grpFiltros.TabStop = False
        grpFiltros.Text = "Filtros"
        ' 
        ' lblDias
        ' 
        lblDias.AutoSize = True
        lblDias.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDias.Location = New Point(839, 43)
        lblDias.Margin = New Padding(4, 0, 4, 0)
        lblDias.Name = "lblDias"
        lblDias.Size = New Size(57, 31)
        lblDias.TabIndex = 8
        lblDias.Text = "dias"
        ' 
        ' lblDiasVencidos
        ' 
        lblDiasVencidos.AutoSize = True
        lblDiasVencidos.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDiasVencidos.Location = New Point(431, 43)
        lblDiasVencidos.Margin = New Padding(4, 0, 4, 0)
        lblDiasVencidos.Name = "lblDiasVencidos"
        lblDiasVencidos.Size = New Size(285, 31)
        lblDiasVencidos.TabIndex = 7
        lblDiasVencidos.Text = "días · vencidas hace hasta"
        ' 
        ' lblvencimiento
        ' 
        lblvencimiento.AutoSize = True
        lblvencimiento.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblvencimiento.Location = New Point(59, 45)
        lblvencimiento.Margin = New Padding(4, 0, 4, 0)
        lblvencimiento.Name = "lblvencimiento"
        lblvencimiento.Size = New Size(268, 31)
        lblvencimiento.TabIndex = 6
        lblvencimiento.Text = "Vencen en los próximos"
        ' 
        ' dgvVencimientos
        ' 
        dgvVencimientos.AllowUserToAddRows = False
        dgvVencimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvVencimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvVencimientos.Location = New Point(17, 263)
        dgvVencimientos.Margin = New Padding(4, 5, 4, 5)
        dgvVencimientos.Name = "dgvVencimientos"
        dgvVencimientos.ReadOnly = True
        dgvVencimientos.RowHeadersVisible = False
        dgvVencimientos.RowHeadersWidth = 62
        dgvVencimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvVencimientos.Size = New Size(1505, 515)
        dgvVencimientos.TabIndex = 9
        ' 
        ' MySqlCommandBuilder1
        ' 
        MySqlCommandBuilder1.DataAdapter = Nothing
        MySqlCommandBuilder1.QuotePrefix = "`"
        MySqlCommandBuilder1.QuoteSuffix = "`"
        ' 
        ' btnConfigurarPágina
        ' 
        btnConfigurarPágina.Enabled = False
        btnConfigurarPágina.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnConfigurarPágina.Location = New Point(17, 815)
        btnConfigurarPágina.Margin = New Padding(4, 5, 4, 5)
        btnConfigurarPágina.Name = "btnConfigurarPágina"
        btnConfigurarPágina.Size = New Size(211, 62)
        btnConfigurarPágina.TabIndex = 10
        btnConfigurarPágina.Text = "Configurar página"
        btnConfigurarPágina.UseVisualStyleBackColor = True
        ' 
        ' btnVistaPrevia
        ' 
        btnVistaPrevia.BackColor = Color.Blue
        btnVistaPrevia.Enabled = False
        btnVistaPrevia.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnVistaPrevia.ForeColor = Color.White
        btnVistaPrevia.Location = New Point(291, 815)
        btnVistaPrevia.Margin = New Padding(4, 5, 4, 5)
        btnVistaPrevia.Name = "btnVistaPrevia"
        btnVistaPrevia.Size = New Size(211, 62)
        btnVistaPrevia.TabIndex = 11
        btnVistaPrevia.Text = "Vista Previa"
        btnVistaPrevia.UseVisualStyleBackColor = False
        ' 
        ' btnImprimir
        ' 
        btnImprimir.Enabled = False
        btnImprimir.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnImprimir.Location = New Point(569, 815)
        btnImprimir.Margin = New Padding(4, 5, 4, 5)
        btnImprimir.Name = "btnImprimir"
        btnImprimir.Size = New Size(211, 62)
        btnImprimir.TabIndex = 12
        btnImprimir.Text = "Imprimir"
        btnImprimir.UseVisualStyleBackColor = True
        ' 
        ' lblResumen
        ' 
        lblResumen.Anchor = AnchorStyles.Right
        lblResumen.AutoSize = True
        lblResumen.Location = New Point(1103, 835)
        lblResumen.Margin = New Padding(4, 0, 4, 0)
        lblResumen.Name = "lblResumen"
        lblResumen.Size = New Size(0, 25)
        lblResumen.TabIndex = 13
        ' 
        ' pdListado
        ' 
        pdListado.DocumentName = "Vencimientos. Eventos usados: BeginPrint, PrintPage, EndPrint"
        ' 
        ' ppdListado
        ' 
        ppdListado.AutoScrollMargin = New Size(0, 0)
        ppdListado.AutoScrollMinSize = New Size(0, 0)
        ppdListado.ClientSize = New Size(400, 300)
        ppdListado.Document = pdListado
        ppdListado.Enabled = True
        ppdListado.Icon = CType(resources.GetObject("ppdListado.Icon"), Icon)
        ppdListado.Name = "ppdListado"
        ppdListado.Visible = False
        ' 
        ' psdListado
        ' 
        psdListado.Document = pdListado
        psdListado.EnableMetric = True
        ' 
        ' prdListado
        ' 
        prdListado.AllowSomePages = True
        prdListado.Document = pdListado
        prdListado.UseEXDialog = True
        ' 
        ' frmListadoVencimientos
        ' 
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1535, 935)
        Controls.Add(lblResumen)
        Controls.Add(btnImprimir)
        Controls.Add(btnVistaPrevia)
        Controls.Add(btnConfigurarPágina)
        Controls.Add(dgvVencimientos)
        Controls.Add(grpFiltros)
        Margin = New Padding(4, 5, 4, 5)
        Name = "frmListadoVencimientos"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Listado de Vencimientos"
        CType(nudDiasAdelante, ComponentModel.ISupportInitialize).EndInit()
        CType(nudDiasAtras, ComponentModel.ISupportInitialize).EndInit()
        grpFiltros.ResumeLayout(False)
        grpFiltros.PerformLayout()
        CType(dgvVencimientos, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents nudDiasAdelante As NumericUpDown
    Friend WithEvents nudDiasAtras As NumericUpDown
    Friend WithEvents chkSoloConSaldo As CheckBox
    Friend WithEvents chkHorizontal As CheckBox
    Friend WithEvents btnCargar As Button
    Friend WithEvents grpFiltros As GroupBox
    Friend WithEvents lblDiasVencidos As Label
    Friend WithEvents lblvencimiento As Label
    Friend WithEvents lblDias As Label
    Friend WithEvents dgvVencimientos As DataGridView
    Friend WithEvents MySqlCommandBuilder1 As MySqlConnector.MySqlCommandBuilder
    Friend WithEvents btnConfigurarPágina As Button
    Friend WithEvents btnVistaPrevia As Button
    Friend WithEvents btnImprimir As Button
    Friend WithEvents lblResumen As Label
    Friend WithEvents pdListado As Printing.PrintDocument
    Friend WithEvents ppdListado As PrintPreviewDialog
    Friend WithEvents psdListado As PageSetupDialog
    Friend WithEvents prdListado As PrintDialog
End Class
