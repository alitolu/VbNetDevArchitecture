Imports System.IO
Imports System.Reflection
Imports System.Xml
Imports log4net
Imports log4net.Repository

Namespace CrossCuttingConcerns.Logging
    Public Class LoggerServiceBase
        Private _log As ILog

        Public Sub New(ByVal name As String)
            Dim xmlDocument As XmlDocument = New XmlDocument()
            xmlDocument.Load(File.OpenRead("log4net.config"))
            Dim loggerRepository As ILoggerRepository = LogManager.CreateRepository(Assembly.GetEntryAssembly(), GetType(Log4Net.Repository.Hierarchy.Hierarchy))
            Log4Net.Config.XmlConfigurator.Configure(loggerRepository, xmlDocument("log4net"))
            _log = LogManager.GetLogger(loggerRepository.Name, name)
        End Sub

        Public ReadOnly Property IsInfoEnabled As Boolean
            Get
                Return _log.IsInfoEnabled
            End Get
        End Property

        Public ReadOnly Property IsDebugEnabled As Boolean
            Get
                Return _log.IsDebugEnabled
            End Get
        End Property

        Public ReadOnly Property IsWarnEnabled As Boolean
            Get
                Return _log.IsWarnEnabled
            End Get
        End Property

        Public ReadOnly Property IsFatalEnabled As Boolean
            Get
                Return _log.IsFatalEnabled
            End Get
        End Property

        Public ReadOnly Property IsErrorEnabled As Boolean
            Get
                Return _log.IsErrorEnabled
            End Get
        End Property

        Public Sub Info(ByVal logMessage As Object)
            If IsInfoEnabled Then _log.Info(logMessage)
        End Sub

        Public Sub Debug(ByVal logMessage As Object)
            If IsDebugEnabled Then _log.Debug(logMessage)
        End Sub

        Public Sub Warn(ByVal logMessage As Object)
            If IsWarnEnabled Then _log.Warn(logMessage)
        End Sub

        Public Sub Fatal(ByVal logMessage As Object)
            If IsFatalEnabled Then _log.Fatal(logMessage)
        End Sub

        Public Sub [Error](ByVal logMessage As Object)
            If IsErrorEnabled Then _log.Error(logMessage)
        End Sub
    End Class
End Namespace
