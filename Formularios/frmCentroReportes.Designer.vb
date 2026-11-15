
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCentroReportes
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        pnlEncabezado = New Panel()
        lblTitulo = New Label()
        picLogo = New PictureBox()
        tvReportes = New TreeView()
        lblNombreReporte = New Label()
        lblDescripcion = New Label()
        grpParametros = New GroupBox()
        pnlParamFechas = New Panel()
        pnlParamSocio = New Panel()
        pnlParamDias = New Panel()
        pnlParamInstructor = New Panel()
        btnVistaPrevia = New Button()
        btnImprimir = New Button()
        btnExportarPdf = New Button()
        btnExportarExcel = New Button()
        btnCerrar = New Button()
        stsEstado = New StatusStrip()
        tslEstado = New ToolStripStatusLabel()
        tspProgreso = New ToolStripProgressBar()
        tslUsuario = New ToolStripStatusLabel()

        pnlEncabezado.SuspendLayout()
        CType(picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        stsEstado.SuspendLayout()
        SuspendLayout()

        pnlEncabezado.BackColor = Color.FromArgb(25, 61, 136)
        pnlEncabezado.Controls.Add(lblTitulo)
        pnlEncabezado.Controls.Add(picLogo)
        pnlEncabezado.Dock = DockStyle.Top
        pnlEncabezado.Height = 70
        pnlEncabezado.Name = "pnlEncabezado"

        picLogo.Location = New Point(12, 5)
        picLogo.Name = "picLogo"
        picLogo.Size = New Size(105, 60)
        picLogo.SizeMode = PictureBoxSizeMode.Zoom
        picLogo.Image = My.Resources.Resources.WhatsApp_Image_2026_10_26_at_10_11_38_PM

        lblTitulo.AutoSize = True
        lblTitulo.Font = New Font("Segoe UI Semibold", 17.0F, FontStyle.Bold)
        lblTitulo.ForeColor = Color.White
        lblTitulo.Location = New Point(135, 19)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Text = "Centro de Reportes"

        tvReportes.Dock = DockStyle.Left
        tvReportes.Width = 290
        tvReportes.Name = "tvReportes"
        tvReportes.Font = New Font("Segoe UI", 10.0F)
        tvReportes.FullRowSelect = True
        tvReportes.HideSelection = False
        tvReportes.ShowLines = False

        lblNombreReporte.Location = New Point(315, 92)
        lblNombreReporte.Name = "lblNombreReporte"
        lblNombreReporte.Size = New Size(735, 38)
        lblNombreReporte.Font = New Font("Segoe UI Semibold", 16.0F, FontStyle.Bold)
        lblNombreReporte.Text = "Seleccione un reporte"
        lblNombreReporte.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

        lblDescripcion.Location = New Point(315, 139)
        lblDescripcion.Name = "lblDescripcion"
        lblDescripcion.Size = New Size(735, 56)
        lblDescripcion.Font = New Font("Segoe UI", 10.0F)
        lblDescripcion.ForeColor = Color.DimGray
        lblDescripcion.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

        grpParametros.Location = New Point(315, 215)
        grpParametros.Name = "grpParametros"
        grpParametros.Size = New Size(735, 285)
        grpParametros.Text = "Parámetros del reporte"
        grpParametros.Font = New Font("Segoe UI", 10.0F)
        grpParametros.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

        pnlParamFechas.Name = "pnlParamFechas"
        pnlParamFechas.Location = New Point(18, 30)
        pnlParamFechas.Size = New Size(690, 235)
        pnlParamFechas.Visible = False

        pnlParamSocio.Name = "pnlParamSocio"
        pnlParamSocio.Location = New Point(18, 30)
        pnlParamSocio.Size = New Size(690, 235)
        pnlParamSocio.Visible = False

        pnlParamDias.Name = "pnlParamDias"
        pnlParamDias.Location = New Point(18, 30)
        pnlParamDias.Size = New Size(690, 235)
        pnlParamDias.Visible = False

        pnlParamInstructor.Name = "pnlParamInstructor"
        pnlParamInstructor.Location = New Point(18, 30)
        pnlParamInstructor.Size = New Size(690, 235)
        pnlParamInstructor.Visible = False

        grpParametros.Controls.Add(pnlParamFechas)
        grpParametros.Controls.Add(pnlParamSocio)
        grpParametros.Controls.Add(pnlParamDias)
        grpParametros.Controls.Add(pnlParamInstructor)

        btnVistaPrevia.Location = New Point(315, 530)
        btnVistaPrevia.Name = "btnVistaPrevia"
        btnVistaPrevia.Size = New Size(130, 40)
        btnVistaPrevia.Text = "Vista previa"
        btnVistaPrevia.BackColor = Color.FromArgb(25, 61, 136)
        btnVistaPrevia.ForeColor = Color.White
        btnVistaPrevia.FlatStyle = FlatStyle.Flat

        btnImprimir.Location = New Point(455, 530)
        btnImprimir.Name = "btnImprimir"
        btnImprimir.Size = New Size(115, 40)
        btnImprimir.Text = "Imprimir"

        btnExportarPdf.Location = New Point(580, 530)
        btnExportarPdf.Name = "btnExportarPdf"
        btnExportarPdf.Size = New Size(130, 40)
        btnExportarPdf.Text = "Exportar PDF"

        btnExportarExcel.Location = New Point(720, 530)
        btnExportarExcel.Name = "btnExportarExcel"
        btnExportarExcel.Size = New Size(135, 40)
        btnExportarExcel.Text = "Exportar Excel"

        btnCerrar.Location = New Point(865, 530)
        btnCerrar.Name = "btnCerrar"
        btnCerrar.Size = New Size(110, 40)
        btnCerrar.Text = "Cerrar"

        stsEstado.Items.AddRange(
            New ToolStripItem() {
                tslEstado,
                tspProgreso,
                tslUsuario
            })
        stsEstado.Dock = DockStyle.Bottom
        stsEstado.Name = "stsEstado"

        tslEstado.Name = "tslEstado"
        tslEstado.Spring = True
        tslEstado.TextAlign = ContentAlignment.MiddleLeft
        tslEstado.Text = "Seleccione un reporte"

        tspProgreso.Name = "tspProgreso"
        tspProgreso.Style = ProgressBarStyle.Marquee
        tspProgreso.Visible = False

        tslUsuario.Name = "tslUsuario"

        AutoScaleDimensions = New SizeF(7.0F, 17.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1084, 660)
        MinimumSize = New Size(1050, 650)
        Font = New Font("Segoe UI", 10.0F)
        Name = "frmCentroReportes"
        StartPosition = FormStartPosition.CenterParent
        Text = "Centro de Reportes - GymControl"

        Controls.Add(stsEstado)
        Controls.Add(btnCerrar)
        Controls.Add(btnExportarExcel)
        Controls.Add(btnExportarPdf)
        Controls.Add(btnImprimir)
        Controls.Add(btnVistaPrevia)
        Controls.Add(grpParametros)
        Controls.Add(lblDescripcion)
        Controls.Add(lblNombreReporte)
        Controls.Add(tvReportes)
        Controls.Add(pnlEncabezado)

        pnlEncabezado.ResumeLayout(False)
        pnlEncabezado.PerformLayout()
        CType(picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        stsEstado.ResumeLayout(False)
        stsEstado.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents picLogo As PictureBox
    Friend WithEvents lblTitulo As Label
    Friend WithEvents tvReportes As TreeView
    Friend WithEvents lblNombreReporte As Label
    Friend WithEvents lblDescripcion As Label
    Friend WithEvents grpParametros As GroupBox
    Friend WithEvents pnlParamFechas As Panel
    Friend WithEvents pnlParamSocio As Panel
    Friend WithEvents pnlParamDias As Panel
    Friend WithEvents pnlParamInstructor As Panel
    Friend WithEvents btnVistaPrevia As Button
    Friend WithEvents btnImprimir As Button
    Friend WithEvents btnExportarPdf As Button
    Friend WithEvents btnExportarExcel As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents stsEstado As StatusStrip
    Friend WithEvents tslEstado As ToolStripStatusLabel
    Friend WithEvents tspProgreso As ToolStripProgressBar
    Friend WithEvents tslUsuario As ToolStripStatusLabel

End Class
