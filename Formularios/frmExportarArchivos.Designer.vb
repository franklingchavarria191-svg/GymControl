<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExportarArchivos
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
        rdbCartera = New RadioButton()
        grpArchivoGenerar = New GroupBox()
        rdbInformeMensual = New RadioButton()
        rdbLibroAnual = New RadioButton()
        dtpMes = New DateTimePicker()
        grpOpciones = New GroupBox()
        nudAnio = New NumericUpDown()
        chkIncluirAlDia = New CheckBox()
        chkAbrirAlTerminar = New CheckBox()
        lblMesInforme = New Label()
        lblAñoLibro = New Label()
        txtRuta = New TextBox()
        btnExaminar = New Button()
        sfdGuardar = New SaveFileDialog()
        btnGenerar = New Button()
        prgAvance = New ProgressBar()
        lblEstado = New Label()
        grpArchivoGenerar.SuspendLayout()
        grpOpciones.SuspendLayout()
        CType(nudAnio, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' rdbCartera
        ' 
        rdbCartera.AutoSize = True
        rdbCartera.Location = New Point(6, 33)
        rdbCartera.Name = "rdbCartera"
        rdbCartera.Size = New Size(14, 13)
        rdbCartera.TabIndex = 0
        rdbCartera.TabStop = True
        rdbCartera.UseVisualStyleBackColor = True
        ' 
        ' grpArchivoGenerar
        ' 
        grpArchivoGenerar.Controls.Add(rdbLibroAnual)
        grpArchivoGenerar.Controls.Add(rdbInformeMensual)
        grpArchivoGenerar.Controls.Add(rdbCartera)
        grpArchivoGenerar.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpArchivoGenerar.Location = New Point(12, 12)
        grpArchivoGenerar.Name = "grpArchivoGenerar"
        grpArchivoGenerar.Size = New Size(362, 117)
        grpArchivoGenerar.TabIndex = 1
        grpArchivoGenerar.TabStop = False
        grpArchivoGenerar.Text = "Archivo a generar"
        ' 
        ' rdbInformeMensual
        ' 
        rdbInformeMensual.AutoSize = True
        rdbInformeMensual.Location = New Point(6, 58)
        rdbInformeMensual.Name = "rdbInformeMensual"
        rdbInformeMensual.Size = New Size(14, 13)
        rdbInformeMensual.TabIndex = 2
        rdbInformeMensual.TabStop = True
        rdbInformeMensual.UseVisualStyleBackColor = True
        ' 
        ' rdbLibroAnual
        ' 
        rdbLibroAnual.AutoSize = True
        rdbLibroAnual.Location = New Point(6, 83)
        rdbLibroAnual.Name = "rdbLibroAnual"
        rdbLibroAnual.Size = New Size(14, 13)
        rdbLibroAnual.TabIndex = 3
        rdbLibroAnual.TabStop = True
        rdbLibroAnual.UseVisualStyleBackColor = True
        ' 
        ' dtpMes
        ' 
        dtpMes.CustomFormat = " MMMM 'de' yyyy"
        dtpMes.Format = DateTimePickerFormat.Custom
        dtpMes.Location = New Point(114, 22)
        dtpMes.Name = "dtpMes"
        dtpMes.ShowUpDown = True
        dtpMes.Size = New Size(200, 23)
        dtpMes.TabIndex = 4
        ' 
        ' grpOpciones
        ' 
        grpOpciones.Controls.Add(lblAñoLibro)
        grpOpciones.Controls.Add(lblMesInforme)
        grpOpciones.Controls.Add(chkAbrirAlTerminar)
        grpOpciones.Controls.Add(chkIncluirAlDia)
        grpOpciones.Controls.Add(nudAnio)
        grpOpciones.Controls.Add(dtpMes)
        grpOpciones.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpOpciones.Location = New Point(422, 12)
        grpOpciones.Name = "grpOpciones"
        grpOpciones.Size = New Size(336, 170)
        grpOpciones.TabIndex = 5
        grpOpciones.TabStop = False
        grpOpciones.Text = "Opciones"
        ' 
        ' nudAnio
        ' 
        nudAnio.Location = New Point(114, 59)
        nudAnio.Maximum = New Decimal(New Integer() {2026, 0, 0, 0})
        nudAnio.Minimum = New Decimal(New Integer() {2024, 0, 0, 0})
        nudAnio.Name = "nudAnio"
        nudAnio.Size = New Size(120, 23)
        nudAnio.TabIndex = 5
        nudAnio.Value = New Decimal(New Integer() {2026, 0, 0, 0})
        ' 
        ' chkIncluirAlDia
        ' 
        chkIncluirAlDia.AutoSize = True
        chkIncluirAlDia.Location = New Point(49, 95)
        chkIncluirAlDia.Name = "chkIncluirAlDia"
        chkIncluirAlDia.Size = New Size(128, 19)
        chkIncluirAlDia.TabIndex = 6
        chkIncluirAlDia.Text = "Incluir socios al día"
        chkIncluirAlDia.UseVisualStyleBackColor = True
        ' 
        ' chkAbrirAlTerminar
        ' 
        chkAbrirAlTerminar.AutoSize = True
        chkAbrirAlTerminar.Checked = True
        chkAbrirAlTerminar.CheckState = CheckState.Checked
        chkAbrirAlTerminar.Location = New Point(49, 131)
        chkAbrirAlTerminar.Name = "chkAbrirAlTerminar"
        chkAbrirAlTerminar.Size = New Size(175, 19)
        chkAbrirAlTerminar.TabIndex = 7
        chkAbrirAlTerminar.Text = "Abrir el archivo al terminar"
        chkAbrirAlTerminar.UseVisualStyleBackColor = True
        ' 
        ' lblMesInforme
        ' 
        lblMesInforme.AutoSize = True
        lblMesInforme.Location = New Point(6, 30)
        lblMesInforme.Name = "lblMesInforme"
        lblMesInforme.Size = New Size(98, 15)
        lblMesInforme.TabIndex = 8
        lblMesInforme.Text = "Mes del informe"
        ' 
        ' lblAñoLibro
        ' 
        lblAñoLibro.AutoSize = True
        lblAñoLibro.Location = New Point(6, 59)
        lblAñoLibro.Name = "lblAñoLibro"
        lblAñoLibro.Size = New Size(77, 15)
        lblAñoLibro.TabIndex = 9
        lblAñoLibro.Text = "Año del libro"
        ' 
        ' txtRuta
        ' 
        txtRuta.Location = New Point(174, 268)
        txtRuta.Name = "txtRuta"
        txtRuta.ReadOnly = True
        txtRuta.Size = New Size(545, 23)
        txtRuta.TabIndex = 10
        ' 
        ' btnExaminar
        ' 
        btnExaminar.Location = New Point(739, 268)
        btnExaminar.Name = "btnExaminar"
        btnExaminar.Size = New Size(75, 23)
        btnExaminar.TabIndex = 11
        btnExaminar.Text = "Examinar..."
        btnExaminar.UseVisualStyleBackColor = True
        ' 
        ' sfdGuardar
        ' 
        sfdGuardar.FileName = "Ingresos_2026.xlsx"
        sfdGuardar.Filter = " Libro de Excel (*.xlsx)|*.xlsx"
        ' 
        ' btnGenerar
        ' 
        btnGenerar.Location = New Point(37, 315)
        btnGenerar.Name = "btnGenerar"
        btnGenerar.Size = New Size(124, 34)
        btnGenerar.TabIndex = 12
        btnGenerar.Text = "Generar Archivos"
        btnGenerar.UseVisualStyleBackColor = True
        ' 
        ' prgAvance
        ' 
        prgAvance.Location = New Point(194, 315)
        prgAvance.MarqueeAnimationSpeed = 30
        prgAvance.Name = "prgAvance"
        prgAvance.Size = New Size(211, 23)
        prgAvance.Style = ProgressBarStyle.Marquee
        prgAvance.TabIndex = 13
        ' 
        ' lblEstado
        ' 
        lblEstado.AutoSize = True
        lblEstado.Location = New Point(422, 315)
        lblEstado.Name = "lblEstado"
        lblEstado.Size = New Size(0, 15)
        lblEstado.TabIndex = 14
        ' 
        ' frmExportarArchivos
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(804, 361)
        Controls.Add(lblEstado)
        Controls.Add(prgAvance)
        Controls.Add(btnGenerar)
        Controls.Add(btnExaminar)
        Controls.Add(txtRuta)
        Controls.Add(grpOpciones)
        Controls.Add(grpArchivoGenerar)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        Name = "frmExportarArchivos"
        StartPosition = FormStartPosition.CenterParent
        Text = "frmExportarArchivos"
        grpArchivoGenerar.ResumeLayout(False)
        grpArchivoGenerar.PerformLayout()
        grpOpciones.ResumeLayout(False)
        grpOpciones.PerformLayout()
        CType(nudAnio, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents rdbCartera As RadioButton
    Friend WithEvents grpArchivoGenerar As GroupBox
    Friend WithEvents rdbLibroAnual As RadioButton
    Friend WithEvents rdbInformeMensual As RadioButton
    Friend WithEvents dtpMes As DateTimePicker
    Friend WithEvents grpOpciones As GroupBox
    Friend WithEvents chkAbrirAlTerminar As CheckBox
    Friend WithEvents chkIncluirAlDia As CheckBox
    Friend WithEvents nudAnio As NumericUpDown
    Friend WithEvents lblAñoLibro As Label
    Friend WithEvents lblMesInforme As Label
    Friend WithEvents txtRuta As TextBox
    Friend WithEvents btnExaminar As Button
    Friend WithEvents sfdGuardar As SaveFileDialog
    Friend WithEvents btnGenerar As Button
    Friend WithEvents prgAvance As ProgressBar
    Friend WithEvents lblEstado As Label
End Class
