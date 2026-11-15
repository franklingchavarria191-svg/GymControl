<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHorarios
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
        cboFiltroInstructor = New ComboBox()
        Label1 = New Label()
        Label2 = New Label()
        cboFiltroSala = New ComboBox()
        btnFiltrar = New Button()
        Button2 = New Button()
        dgvSemana = New DataGridView()
        Lunes = New DataGridViewTextBoxColumn()
        Martes = New DataGridViewTextBoxColumn()
        Miercoles = New DataGridViewTextBoxColumn()
        Jueves = New DataGridViewTextBoxColumn()
        Viernes = New DataGridViewTextBoxColumn()
        Sabado = New DataGridViewTextBoxColumn()
        grpDetalle = New GroupBox()
        chkActivo = New CheckBox()
        btnEliminar = New Button()
        btnGuardar = New Button()
        btnNuevo = New Button()
        cboDia = New ComboBox()
        cboSala = New ComboBox()
        cboActividad = New ComboBox()
        cboInstructor = New ComboBox()
        Label8 = New Label()
        Label3 = New Label()
        Label7 = New Label()
        Label4 = New Label()
        Label6 = New Label()
        Label5 = New Label()
        lblChoque = New Panel()
        Label10 = New Label()
        Label9 = New Label()
        dtpHoraInicio = New DateTimePicker()
        dtpHoraFin = New DateTimePicker()
        CType(dgvSemana, ComponentModel.ISupportInitialize).BeginInit()
        grpDetalle.SuspendLayout()
        lblChoque.SuspendLayout()
        SuspendLayout()
        ' 
        ' cboFiltroInstructor
        ' 
        cboFiltroInstructor.FormattingEnabled = True
        cboFiltroInstructor.Location = New Point(125, 40)
        cboFiltroInstructor.Margin = New Padding(4, 5, 4, 5)
        cboFiltroInstructor.Name = "cboFiltroInstructor"
        cboFiltroInstructor.Size = New Size(196, 33)
        cboFiltroInstructor.TabIndex = 0
        cboFiltroInstructor.Text = "Todos"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(25, 43)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(92, 25)
        Label1.TabIndex = 1
        Label1.Text = "Instructor:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(339, 41)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(48, 25)
        Label2.TabIndex = 2
        Label2.Text = "Sala:"
        ' 
        ' cboFiltroSala
        ' 
        cboFiltroSala.FormattingEnabled = True
        cboFiltroSala.Location = New Point(395, 38)
        cboFiltroSala.Margin = New Padding(4, 5, 4, 5)
        cboFiltroSala.Name = "cboFiltroSala"
        cboFiltroSala.Size = New Size(191, 33)
        cboFiltroSala.TabIndex = 3
        ' 
        ' btnFiltrar
        ' 
        btnFiltrar.Location = New Point(612, 35)
        btnFiltrar.Margin = New Padding(4, 5, 4, 5)
        btnFiltrar.Name = "btnFiltrar"
        btnFiltrar.Size = New Size(107, 38)
        btnFiltrar.TabIndex = 4
        btnFiltrar.Text = "Filtrar"
        btnFiltrar.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(727, 38)
        Button2.Margin = New Padding(4, 5, 4, 5)
        Button2.Name = "Button2"
        Button2.Size = New Size(171, 38)
        Button2.TabIndex = 5
        Button2.Text = "Imprimir semana"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' dgvSemana
        ' 
        dgvSemana.AllowUserToOrderColumns = True
        dgvSemana.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvSemana.Columns.AddRange(New DataGridViewColumn() {Lunes, Martes, Miercoles, Jueves, Viernes, Sabado})
        dgvSemana.Location = New Point(13, 95)
        dgvSemana.Margin = New Padding(4, 5, 4, 5)
        dgvSemana.Name = "dgvSemana"
        dgvSemana.RowHeadersWidth = 62
        dgvSemana.Size = New Size(964, 839)
        dgvSemana.TabIndex = 6
        ' 
        ' Lunes
        ' 
        Lunes.HeaderText = "Lunes"
        Lunes.MinimumWidth = 8
        Lunes.Name = "Lunes"
        Lunes.Width = 150
        ' 
        ' Martes
        ' 
        Martes.HeaderText = "Martes"
        Martes.MinimumWidth = 8
        Martes.Name = "Martes"
        Martes.Width = 150
        ' 
        ' Miercoles
        ' 
        Miercoles.HeaderText = "Miercoles"
        Miercoles.MinimumWidth = 8
        Miercoles.Name = "Miercoles"
        Miercoles.Width = 150
        ' 
        ' Jueves
        ' 
        Jueves.HeaderText = "Jueves"
        Jueves.MinimumWidth = 8
        Jueves.Name = "Jueves"
        Jueves.Width = 150
        ' 
        ' Viernes
        ' 
        Viernes.HeaderText = "Viernes"
        Viernes.MinimumWidth = 8
        Viernes.Name = "Viernes"
        Viernes.Width = 150
        ' 
        ' Sabado
        ' 
        Sabado.HeaderText = "Sabado"
        Sabado.MinimumWidth = 8
        Sabado.Name = "Sabado"
        Sabado.Width = 150
        ' 
        ' grpDetalle
        ' 
        grpDetalle.Controls.Add(dtpHoraFin)
        grpDetalle.Controls.Add(dtpHoraInicio)
        grpDetalle.Controls.Add(chkActivo)
        grpDetalle.Controls.Add(btnEliminar)
        grpDetalle.Controls.Add(btnGuardar)
        grpDetalle.Controls.Add(btnNuevo)
        grpDetalle.Controls.Add(cboDia)
        grpDetalle.Controls.Add(cboSala)
        grpDetalle.Controls.Add(cboActividad)
        grpDetalle.Controls.Add(cboInstructor)
        grpDetalle.Controls.Add(Label8)
        grpDetalle.Controls.Add(Label3)
        grpDetalle.Controls.Add(Label7)
        grpDetalle.Controls.Add(Label4)
        grpDetalle.Controls.Add(Label6)
        grpDetalle.Controls.Add(Label5)
        grpDetalle.Location = New Point(993, 95)
        grpDetalle.Margin = New Padding(4, 5, 4, 5)
        grpDetalle.Name = "grpDetalle"
        grpDetalle.Padding = New Padding(4, 5, 4, 5)
        grpDetalle.Size = New Size(736, 582)
        grpDetalle.TabIndex = 7
        grpDetalle.TabStop = False
        grpDetalle.Text = "Detalles del horario"
        ' 
        ' chkActivo
        ' 
        chkActivo.AutoSize = True
        chkActivo.Checked = True
        chkActivo.CheckState = CheckState.Checked
        chkActivo.Location = New Point(9, 443)
        chkActivo.Margin = New Padding(4, 5, 4, 5)
        chkActivo.Name = "chkActivo"
        chkActivo.Size = New Size(88, 29)
        chkActivo.TabIndex = 8
        chkActivo.Text = "Activo"
        chkActivo.UseVisualStyleBackColor = True
        ' 
        ' btnEliminar
        ' 
        btnEliminar.Location = New Point(467, 493)
        btnEliminar.Margin = New Padding(4, 5, 4, 5)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(226, 60)
        btnEliminar.TabIndex = 20
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = True
        ' 
        ' btnGuardar
        ' 
        btnGuardar.Location = New Point(256, 493)
        btnGuardar.Margin = New Padding(4, 5, 4, 5)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(203, 60)
        btnGuardar.TabIndex = 19
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = True
        ' 
        ' btnNuevo
        ' 
        btnNuevo.Location = New Point(9, 493)
        btnNuevo.Margin = New Padding(4, 5, 4, 5)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New Size(239, 60)
        btnNuevo.TabIndex = 18
        btnNuevo.Text = "Nuevo"
        btnNuevo.UseVisualStyleBackColor = True
        ' 
        ' cboDia
        ' 
        cboDia.FormattingEnabled = True
        cboDia.Location = New Point(200, 243)
        cboDia.Margin = New Padding(4, 5, 4, 5)
        cboDia.Name = "cboDia"
        cboDia.Size = New Size(525, 33)
        cboDia.TabIndex = 17
        ' 
        ' cboSala
        ' 
        cboSala.FormattingEnabled = True
        cboSala.Location = New Point(200, 175)
        cboSala.Margin = New Padding(4, 5, 4, 5)
        cboSala.Name = "cboSala"
        cboSala.Size = New Size(525, 33)
        cboSala.TabIndex = 16
        ' 
        ' cboActividad
        ' 
        cboActividad.FormattingEnabled = True
        cboActividad.Location = New Point(200, 108)
        cboActividad.Margin = New Padding(4, 5, 4, 5)
        cboActividad.Name = "cboActividad"
        cboActividad.Size = New Size(525, 33)
        cboActividad.TabIndex = 15
        ' 
        ' cboInstructor
        ' 
        cboInstructor.FormattingEnabled = True
        cboInstructor.Location = New Point(200, 50)
        cboInstructor.Margin = New Padding(4, 5, 4, 5)
        cboInstructor.Name = "cboInstructor"
        cboInstructor.Size = New Size(525, 33)
        cboInstructor.TabIndex = 14
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(9, 380)
        Label8.Margin = New Padding(4, 0, 4, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(84, 25)
        Label8.TabIndex = 13
        Label8.Text = "Hora fin*"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(9, 50)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(96, 25)
        Label3.TabIndex = 8
        Label3.Text = "Instructor*"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(9, 310)
        Label7.Margin = New Padding(4, 0, 4, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(105, 25)
        Label7.TabIndex = 12
        Label7.Text = "Hora inicio*"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(9, 108)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(94, 25)
        Label4.TabIndex = 9
        Label4.Text = "Actividad*"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(9, 243)
        Label6.Margin = New Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(46, 25)
        Label6.TabIndex = 11
        Label6.Text = "Dia*"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(9, 175)
        Label5.Margin = New Padding(4, 0, 4, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(52, 25)
        Label5.TabIndex = 10
        Label5.Text = "Sala*"
        ' 
        ' lblChoque
        ' 
        lblChoque.Controls.Add(Label10)
        lblChoque.Controls.Add(Label9)
        lblChoque.Location = New Point(993, 687)
        lblChoque.Margin = New Padding(4, 5, 4, 5)
        lblChoque.Name = "lblChoque"
        lblChoque.Size = New Size(727, 247)
        lblChoque.TabIndex = 21
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(4, 65)
        Label10.Margin = New Padding(4, 0, 4, 0)
        Label10.Name = "Label10"
        Label10.Size = New Size(792, 25)
        Label10.TabIndex = 23
        Label10.Text = "La sala ciclo ya esta ocuoada el Lunes de 06:00 a.m a 07:00 a.m (). No se  puede guardar el registro"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(4, 24)
        Label9.Margin = New Padding(4, 0, 4, 0)
        Label9.Name = "Label9"
        Label9.Size = New Size(254, 25)
        Label9.TabIndex = 22
        Label9.Text = "Choque de horarios detectado"
        ' 
        ' dtpHoraInicio
        ' 
        dtpHoraInicio.Location = New Point(200, 310)
        dtpHoraInicio.Name = "dtpHoraInicio"
        dtpHoraInicio.Size = New Size(525, 31)
        dtpHoraInicio.TabIndex = 21
        ' 
        ' dtpHoraFin
        ' 
        dtpHoraFin.Location = New Point(200, 375)
        dtpHoraFin.Name = "dtpHoraFin"
        dtpHoraFin.Size = New Size(525, 31)
        dtpHoraFin.TabIndex = 22
        ' 
        ' frmHorarios
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1746, 1082)
        Controls.Add(lblChoque)
        Controls.Add(grpDetalle)
        Controls.Add(dgvSemana)
        Controls.Add(Button2)
        Controls.Add(btnFiltrar)
        Controls.Add(cboFiltroSala)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(cboFiltroInstructor)
        Margin = New Padding(4, 5, 4, 5)
        Name = "frmHorarios"
        Text = "Horario de instructores"
        CType(dgvSemana, ComponentModel.ISupportInitialize).EndInit()
        grpDetalle.ResumeLayout(False)
        grpDetalle.PerformLayout()
        lblChoque.ResumeLayout(False)
        lblChoque.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents cboFiltroInstructor As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cboFiltroSala As ComboBox
    Friend WithEvents btnFiltrar As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents dgvSemana As DataGridView
    Friend WithEvents Lunes As DataGridViewTextBoxColumn
    Friend WithEvents Martes As DataGridViewTextBoxColumn
    Friend WithEvents Miercoles As DataGridViewTextBoxColumn
    Friend WithEvents Jueves As DataGridViewTextBoxColumn
    Friend WithEvents Viernes As DataGridViewTextBoxColumn
    Friend WithEvents Sabado As DataGridViewTextBoxColumn
    Friend WithEvents grpDetalle As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents chkActivo As CheckBox
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents cboDia As ComboBox
    Friend WithEvents cboSala As ComboBox
    Friend WithEvents cboActividad As ComboBox
    Friend WithEvents cboInstructor As ComboBox
    Friend WithEvents lblChoque As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents dtpHoraFin As DateTimePicker
    Friend WithEvents dtpHoraInicio As DateTimePicker
End Class
