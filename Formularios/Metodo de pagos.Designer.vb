<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Metodo_de_pagos
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
        iblTitulo = New Label()
        grpRegistrarPago = New GroupBox()
        Button2 = New Button()
        Button1 = New Button()
        Label7 = New Label()
        TextBox2 = New TextBox()
        Label6 = New Label()
        TextBox1 = New TextBox()
        ComboBox1 = New ComboBox()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        nudMonto = New NumericUpDown()
        cboMembresia = New ComboBox()
        cboSocio = New ComboBox()
        btnBuscarSocio = New Button()
        txtBuscarSocio = New TextBox()
        Label1 = New Label()
        grpInformacion = New GroupBox()
        Label9 = New Label()
        Label8 = New Label()
        iblPrecioTotal = New Label()
        iblFechaVencimiento = New Label()
        iblFechaInicio = New Label()
        iblTipoMembresia = New Label()
        iblMembresia = New Label()
        iblSocio = New Label()
        GroupBox1 = New GroupBox()
        btnCerrar = New Button()
        btnAnularPago = New Button()
        DGVpAGOS = New DataGridView()
        Column1 = New DataGridViewTextBoxColumn()
        Column2 = New DataGridViewTextBoxColumn()
        Column3 = New DataGridViewTextBoxColumn()
        Column4 = New DataGridViewTextBoxColumn()
        Column5 = New DataGridViewTextBoxColumn()
        Column6 = New DataGridViewTextBoxColumn()
        Column7 = New DataGridViewTextBoxColumn()
        Column8 = New DataGridViewTextBoxColumn()
        Column9 = New DataGridViewTextBoxColumn()
        DateTimePicker2 = New DateTimePicker()
        DateTimePicker1 = New DateTimePicker()
        Label12 = New Label()
        Label11 = New Label()
        cboEstado = New ComboBox()
        Label10 = New Label()
        TextBox3 = New TextBox()
        btnBuscarPago = New Button()
        iblBuscarPago = New Label()
        grpRegistrarPago.SuspendLayout()
        CType(nudMonto, ComponentModel.ISupportInitialize).BeginInit()
        grpInformacion.SuspendLayout()
        GroupBox1.SuspendLayout()
        CType(DGVpAGOS, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' iblTitulo
        ' 
        iblTitulo.AutoSize = True
        iblTitulo.Location = New Point(3, 15)
        iblTitulo.Margin = New Padding(4, 0, 4, 0)
        iblTitulo.Name = "iblTitulo"
        iblTitulo.Size = New Size(152, 25)
        iblTitulo.TabIndex = 0
        iblTitulo.Text = "Gestion de pagos"
        ' 
        ' grpRegistrarPago
        ' 
        grpRegistrarPago.Controls.Add(Button2)
        grpRegistrarPago.Controls.Add(Button1)
        grpRegistrarPago.Controls.Add(Label7)
        grpRegistrarPago.Controls.Add(TextBox2)
        grpRegistrarPago.Controls.Add(Label6)
        grpRegistrarPago.Controls.Add(TextBox1)
        grpRegistrarPago.Controls.Add(ComboBox1)
        grpRegistrarPago.Controls.Add(Label5)
        grpRegistrarPago.Controls.Add(Label4)
        grpRegistrarPago.Controls.Add(Label3)
        grpRegistrarPago.Controls.Add(Label2)
        grpRegistrarPago.Controls.Add(nudMonto)
        grpRegistrarPago.Controls.Add(cboMembresia)
        grpRegistrarPago.Controls.Add(cboSocio)
        grpRegistrarPago.Controls.Add(btnBuscarSocio)
        grpRegistrarPago.Controls.Add(txtBuscarSocio)
        grpRegistrarPago.Controls.Add(Label1)
        grpRegistrarPago.Location = New Point(0, 0)
        grpRegistrarPago.Margin = New Padding(4, 5, 4, 5)
        grpRegistrarPago.Name = "grpRegistrarPago"
        grpRegistrarPago.Padding = New Padding(4, 5, 4, 5)
        grpRegistrarPago.Size = New Size(941, 540)
        grpRegistrarPago.TabIndex = 1
        grpRegistrarPago.TabStop = False
        grpRegistrarPago.Text = "Registrar pago"
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(477, 353)
        Button2.Margin = New Padding(4, 5, 4, 5)
        Button2.Name = "Button2"
        Button2.Size = New Size(247, 65)
        Button2.TabIndex = 16
        Button2.Text = "Limpiar"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(209, 353)
        Button1.Margin = New Padding(4, 5, 4, 5)
        Button1.Name = "Button1"
        Button1.Size = New Size(260, 65)
        Button1.TabIndex = 15
        Button1.Text = "Registrar pago"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(0, 283)
        Label7.Margin = New Padding(4, 0, 4, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(115, 25)
        Label7.TabIndex = 14
        Label7.Text = "Observacion:"
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(124, 278)
        TextBox2.Margin = New Padding(4, 5, 4, 5)
        TextBox2.Multiline = True
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(737, 36)
        TextBox2.TabIndex = 13
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(0, 235)
        Label6.Margin = New Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(96, 25)
        Label6.TabIndex = 12
        Label6.Text = "Referencia:"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(124, 230)
        TextBox1.Margin = New Padding(4, 5, 4, 5)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(737, 31)
        TextBox1.TabIndex = 11
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(509, 182)
        ComboBox1.Margin = New Padding(4, 5, 4, 5)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(353, 33)
        ComboBox1.TabIndex = 10
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(360, 185)
        Label5.Margin = New Padding(4, 0, 4, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(152, 25)
        Label5.TabIndex = 9
        Label5.Text = "Metodo de pago:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(0, 185)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(70, 25)
        Label4.TabIndex = 8
        Label4.Text = "Monto:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(0, 138)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(104, 25)
        Label3.TabIndex = 7
        Label3.Text = "Membresia:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(0, 90)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(60, 25)
        Label2.TabIndex = 6
        Label2.Text = "Socio:"
        ' 
        ' nudMonto
        ' 
        nudMonto.DecimalPlaces = 2
        nudMonto.Location = New Point(124, 182)
        nudMonto.Margin = New Padding(4, 5, 4, 5)
        nudMonto.Name = "nudMonto"
        nudMonto.Size = New Size(227, 31)
        nudMonto.TabIndex = 5
        ' 
        ' cboMembresia
        ' 
        cboMembresia.FormattingEnabled = True
        cboMembresia.Location = New Point(124, 133)
        cboMembresia.Margin = New Padding(4, 5, 4, 5)
        cboMembresia.Name = "cboMembresia"
        cboMembresia.Size = New Size(737, 33)
        cboMembresia.TabIndex = 4
        ' 
        ' cboSocio
        ' 
        cboSocio.FormattingEnabled = True
        cboSocio.Location = New Point(124, 85)
        cboSocio.Margin = New Padding(4, 5, 4, 5)
        cboSocio.Name = "cboSocio"
        cboSocio.Size = New Size(737, 33)
        cboSocio.TabIndex = 3
        ' 
        ' btnBuscarSocio
        ' 
        btnBuscarSocio.Location = New Point(691, 42)
        btnBuscarSocio.Margin = New Padding(4, 5, 4, 5)
        btnBuscarSocio.Name = "btnBuscarSocio"
        btnBuscarSocio.Size = New Size(171, 38)
        btnBuscarSocio.TabIndex = 2
        btnBuscarSocio.Text = "Buscar"
        btnBuscarSocio.UseVisualStyleBackColor = True
        ' 
        ' txtBuscarSocio
        ' 
        txtBuscarSocio.Location = New Point(124, 37)
        txtBuscarSocio.Margin = New Padding(4, 5, 4, 5)
        txtBuscarSocio.Name = "txtBuscarSocio"
        txtBuscarSocio.PlaceholderText = "Ingrese nombre, apellido oID"
        txtBuscarSocio.Size = New Size(557, 31)
        txtBuscarSocio.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(0, 42)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(122, 25)
        Label1.TabIndex = 0
        Label1.Text = "Buscar socios:"
        ' 
        ' grpInformacion
        ' 
        grpInformacion.Controls.Add(Label9)
        grpInformacion.Controls.Add(Label8)
        grpInformacion.Controls.Add(iblPrecioTotal)
        grpInformacion.Controls.Add(iblFechaVencimiento)
        grpInformacion.Controls.Add(iblFechaInicio)
        grpInformacion.Controls.Add(iblTipoMembresia)
        grpInformacion.Controls.Add(iblMembresia)
        grpInformacion.Controls.Add(iblSocio)
        grpInformacion.Location = New Point(950, 15)
        grpInformacion.Margin = New Padding(4, 5, 4, 5)
        grpInformacion.Name = "grpInformacion"
        grpInformacion.Padding = New Padding(4, 5, 4, 5)
        grpInformacion.Size = New Size(931, 525)
        grpInformacion.TabIndex = 17
        grpInformacion.TabStop = False
        grpInformacion.Text = "Informacion de la membresia seleccionada"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(251, 230)
        Label9.Margin = New Padding(4, 0, 4, 0)
        Label9.Name = "Label9"
        Label9.Size = New Size(145, 25)
        Label9.TabIndex = 7
        Label9.Text = "Saldo pendiente:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(251, 205)
        Label8.Margin = New Padding(4, 0, 4, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(137, 25)
        Label8.TabIndex = 6
        Label8.Text = "Monto pagado:"
        ' 
        ' iblPrecioTotal
        ' 
        iblPrecioTotal.AutoSize = True
        iblPrecioTotal.Location = New Point(60, 230)
        iblPrecioTotal.Margin = New Padding(4, 0, 4, 0)
        iblPrecioTotal.Name = "iblPrecioTotal"
        iblPrecioTotal.Size = New Size(105, 25)
        iblPrecioTotal.TabIndex = 5
        iblPrecioTotal.Text = "Precio total:"
        ' 
        ' iblFechaVencimiento
        ' 
        iblFechaVencimiento.AutoSize = True
        iblFechaVencimiento.Location = New Point(60, 205)
        iblFechaVencimiento.Margin = New Padding(4, 0, 4, 0)
        iblFechaVencimiento.Name = "iblFechaVencimiento"
        iblFechaVencimiento.Size = New Size(162, 25)
        iblFechaVencimiento.TabIndex = 4
        iblFechaVencimiento.Text = "Fecha vencimiento:"
        ' 
        ' iblFechaInicio
        ' 
        iblFechaInicio.AutoSize = True
        iblFechaInicio.Location = New Point(60, 180)
        iblFechaInicio.Margin = New Padding(4, 0, 4, 0)
        iblFechaInicio.Name = "iblFechaInicio"
        iblFechaInicio.Size = New Size(107, 25)
        iblFechaInicio.TabIndex = 3
        iblFechaInicio.Text = "Fecha inicio:"
        ' 
        ' iblTipoMembresia
        ' 
        iblTipoMembresia.AutoSize = True
        iblTipoMembresia.Location = New Point(4, 123)
        iblTipoMembresia.Margin = New Padding(4, 0, 4, 0)
        iblTipoMembresia.Name = "iblTipoMembresia"
        iblTipoMembresia.Size = New Size(51, 25)
        iblTipoMembresia.TabIndex = 2
        iblTipoMembresia.Text = "Tipo:"
        ' 
        ' iblMembresia
        ' 
        iblMembresia.AutoSize = True
        iblMembresia.Location = New Point(4, 75)
        iblMembresia.Margin = New Padding(4, 0, 4, 0)
        iblMembresia.Name = "iblMembresia"
        iblMembresia.Size = New Size(104, 25)
        iblMembresia.TabIndex = 1
        iblMembresia.Text = "Membresia:"
        ' 
        ' iblSocio
        ' 
        iblSocio.AutoSize = True
        iblSocio.Location = New Point(4, 32)
        iblSocio.Margin = New Padding(4, 0, 4, 0)
        iblSocio.Name = "iblSocio"
        iblSocio.Size = New Size(60, 25)
        iblSocio.TabIndex = 0
        iblSocio.Text = "Socio:"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(btnCerrar)
        GroupBox1.Controls.Add(btnAnularPago)
        GroupBox1.Controls.Add(DGVpAGOS)
        GroupBox1.Controls.Add(DateTimePicker2)
        GroupBox1.Controls.Add(DateTimePicker1)
        GroupBox1.Controls.Add(Label12)
        GroupBox1.Controls.Add(Label11)
        GroupBox1.Controls.Add(cboEstado)
        GroupBox1.Controls.Add(Label10)
        GroupBox1.Controls.Add(TextBox3)
        GroupBox1.Controls.Add(btnBuscarPago)
        GroupBox1.Controls.Add(iblBuscarPago)
        GroupBox1.Location = New Point(3, 550)
        GroupBox1.Margin = New Padding(4, 5, 4, 5)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(4, 5, 4, 5)
        GroupBox1.Size = New Size(1879, 508)
        GroupBox1.TabIndex = 8
        GroupBox1.TabStop = False
        GroupBox1.Text = "Pagos registrados"
        ' 
        ' btnCerrar
        ' 
        btnCerrar.Location = New Point(1466, 400)
        btnCerrar.Margin = New Padding(4, 5, 4, 5)
        btnCerrar.Name = "btnCerrar"
        btnCerrar.Size = New Size(194, 75)
        btnCerrar.TabIndex = 11
        btnCerrar.Text = "Cerrar"
        btnCerrar.UseVisualStyleBackColor = True
        ' 
        ' btnAnularPago
        ' 
        btnAnularPago.Location = New Point(1263, 400)
        btnAnularPago.Margin = New Padding(4, 5, 4, 5)
        btnAnularPago.Name = "btnAnularPago"
        btnAnularPago.Size = New Size(194, 75)
        btnAnularPago.TabIndex = 10
        btnAnularPago.Text = "Anular pago"
        btnAnularPago.UseVisualStyleBackColor = True
        ' 
        ' DGVpAGOS
        ' 
        DGVpAGOS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGVpAGOS.Columns.AddRange(New DataGridViewColumn() {Column1, Column2, Column3, Column4, Column5, Column6, Column7, Column8, Column9})
        DGVpAGOS.Location = New Point(6, 117)
        DGVpAGOS.Margin = New Padding(4, 5, 4, 5)
        DGVpAGOS.Name = "DGVpAGOS"
        DGVpAGOS.RowHeadersWidth = 62
        DGVpAGOS.Size = New Size(1774, 250)
        DGVpAGOS.TabIndex = 9
        ' 
        ' Column1
        ' 
        Column1.HeaderText = "ID"
        Column1.MinimumWidth = 8
        Column1.Name = "Column1"
        Column1.Width = 150
        ' 
        ' Column2
        ' 
        Column2.HeaderText = "Fecha de pago"
        Column2.MinimumWidth = 8
        Column2.Name = "Column2"
        Column2.Width = 150
        ' 
        ' Column3
        ' 
        Column3.HeaderText = "Socio"
        Column3.MinimumWidth = 8
        Column3.Name = "Column3"
        Column3.Width = 150
        ' 
        ' Column4
        ' 
        Column4.HeaderText = "Membresia"
        Column4.MinimumWidth = 8
        Column4.Name = "Column4"
        Column4.Width = 150
        ' 
        ' Column5
        ' 
        Column5.HeaderText = "monto"
        Column5.MinimumWidth = 8
        Column5.Name = "Column5"
        Column5.Width = 150
        ' 
        ' Column6
        ' 
        Column6.HeaderText = "Metodo"
        Column6.MinimumWidth = 8
        Column6.Name = "Column6"
        Column6.Width = 150
        ' 
        ' Column7
        ' 
        Column7.HeaderText = "Referencia"
        Column7.MinimumWidth = 8
        Column7.Name = "Column7"
        Column7.Width = 150
        ' 
        ' Column8
        ' 
        Column8.HeaderText = "Observacion"
        Column8.MinimumWidth = 8
        Column8.Name = "Column8"
        Column8.Width = 150
        ' 
        ' Column9
        ' 
        Column9.HeaderText = "Estado"
        Column9.MinimumWidth = 8
        Column9.Name = "Column9"
        Column9.Width = 150
        ' 
        ' DateTimePicker2
        ' 
        DateTimePicker2.Format = DateTimePickerFormat.Short
        DateTimePicker2.Location = New Point(1494, 62)
        DateTimePicker2.Margin = New Padding(4, 5, 4, 5)
        DateTimePicker2.Name = "DateTimePicker2"
        DateTimePicker2.Size = New Size(284, 31)
        DateTimePicker2.TabIndex = 8
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Format = DateTimePickerFormat.Short
        DateTimePicker1.Location = New Point(1134, 62)
        DateTimePicker1.Margin = New Padding(4, 5, 4, 5)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(284, 31)
        DateTimePicker1.TabIndex = 7
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(1429, 68)
        Label12.Margin = New Padding(4, 0, 4, 0)
        Label12.Name = "Label12"
        Label12.Size = New Size(61, 25)
        Label12.TabIndex = 6
        Label12.Text = "Hasta:"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(1066, 62)
        Label11.Margin = New Padding(4, 0, 4, 0)
        Label11.Name = "Label11"
        Label11.Size = New Size(66, 25)
        Label11.TabIndex = 5
        Label11.Text = "Desde:"
        ' 
        ' cboEstado
        ' 
        cboEstado.FormattingEnabled = True
        cboEstado.Items.AddRange(New Object() {"Todos", "Valido", "Anulado"})
        cboEstado.Location = New Point(866, 55)
        cboEstado.Margin = New Padding(4, 5, 4, 5)
        cboEstado.Name = "cboEstado"
        cboEstado.Size = New Size(171, 33)
        cboEstado.TabIndex = 4
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(793, 55)
        Label10.Margin = New Padding(4, 0, 4, 0)
        Label10.Name = "Label10"
        Label10.Size = New Size(70, 25)
        Label10.TabIndex = 3
        Label10.Text = "Estado:"
        ' 
        ' TextBox3
        ' 
        TextBox3.Location = New Point(144, 48)
        TextBox3.Margin = New Padding(4, 5, 4, 5)
        TextBox3.Name = "TextBox3"
        TextBox3.PlaceholderText = "Ingrese nombre, monto, referencia..."
        TextBox3.Size = New Size(410, 31)
        TextBox3.TabIndex = 2
        ' 
        ' btnBuscarPago
        ' 
        btnBuscarPago.Location = New Point(564, 48)
        btnBuscarPago.Margin = New Padding(4, 5, 4, 5)
        btnBuscarPago.Name = "btnBuscarPago"
        btnBuscarPago.Size = New Size(107, 38)
        btnBuscarPago.TabIndex = 1
        btnBuscarPago.Text = "Buscar"
        btnBuscarPago.UseVisualStyleBackColor = True
        ' 
        ' iblBuscarPago
        ' 
        iblBuscarPago.AutoSize = True
        iblBuscarPago.Location = New Point(29, 48)
        iblBuscarPago.Margin = New Padding(4, 0, 4, 0)
        iblBuscarPago.Name = "iblBuscarPago"
        iblBuscarPago.Size = New Size(114, 25)
        iblBuscarPago.TabIndex = 0
        iblBuscarPago.Text = "Buscar pago:"
        ' 
        ' Metodo_de_pagos
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1899, 1170)
        Controls.Add(GroupBox1)
        Controls.Add(grpInformacion)
        Controls.Add(grpRegistrarPago)
        Controls.Add(iblTitulo)
        Margin = New Padding(4, 5, 4, 5)
        Name = "Metodo_de_pagos"
        Text = "Metodo_de_pagos"
        grpRegistrarPago.ResumeLayout(False)
        grpRegistrarPago.PerformLayout()
        CType(nudMonto, ComponentModel.ISupportInitialize).EndInit()
        grpInformacion.ResumeLayout(False)
        grpInformacion.PerformLayout()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(DGVpAGOS, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents iblTitulo As Label
    Friend WithEvents grpRegistrarPago As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents nudMonto As NumericUpDown
    Friend WithEvents cboMembresia As ComboBox
    Friend WithEvents cboSocio As ComboBox
    Friend WithEvents btnBuscarSocio As Button
    Friend WithEvents txtBuscarSocio As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents grpInformacion As GroupBox
    Friend WithEvents iblSocio As Label
    Friend WithEvents iblPrecioTotal As Label
    Friend WithEvents iblFechaVencimiento As Label
    Friend WithEvents iblFechaInicio As Label
    Friend WithEvents iblTipoMembresia As Label
    Friend WithEvents iblMembresia As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnBuscarPago As Button
    Friend WithEvents iblBuscarPago As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents cboEstado As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents btnAnularPago As Button
    Friend WithEvents DGVpAGOS As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents DateTimePicker2 As DateTimePicker
End Class
