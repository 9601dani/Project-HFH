<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form7
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ConCelularesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.basexelaDataSet1 = New WindowsApplication1.basexelaDataSet1()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ConCelularesTableAdapter = New WindowsApplication1.basexelaDataSet1TableAdapters.ConCelularesTableAdapter()
        CType(Me.ConCelularesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.basexelaDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ConCelularesBindingSource
        '
        Me.ConCelularesBindingSource.DataMember = "ConCelulares"
        Me.ConCelularesBindingSource.DataSource = Me.basexelaDataSet1
        '
        'basexelaDataSet1
        '
        Me.basexelaDataSet1.DataSetName = "basexelaDataSet1"
        Me.basexelaDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReportViewer1.AutoSize = True
        ReportDataSource1.Name = "DataSet2"
        ReportDataSource1.Value = Me.ConCelularesBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "WindowsApplication1.Report1.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 12)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(853, 346)
        Me.ReportViewer1.TabIndex = 0
        '
        'ConCelularesTableAdapter
        '
        Me.ConCelularesTableAdapter.ClearBeforeFill = True
        '
        'Form7
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(877, 370)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "Form7"
        CType(Me.ConCelularesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.basexelaDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ConCelularesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents basexelaDataSet1 As WindowsApplication1.basexelaDataSet1
    Friend WithEvents ConCelularesTableAdapter As WindowsApplication1.basexelaDataSet1TableAdapters.ConCelularesTableAdapter
End Class
