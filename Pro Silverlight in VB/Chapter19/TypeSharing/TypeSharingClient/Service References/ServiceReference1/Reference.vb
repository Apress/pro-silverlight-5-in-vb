﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.235
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


'
'This code was auto-generated by Microsoft.Silverlight.ServiceReference, version 5.0.60818.0
'
Namespace ServiceReference1
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute([Namespace]:="", ConfigurationName:="ServiceReference1.TestService")>  _
    Public Interface TestService
        
        <System.ServiceModel.OperationContractAttribute(AsyncPattern:=true, Action:="urn:TestService/GetCustomer", ReplyAction:="urn:TestService/GetCustomerResponse")>  _
        Function BeginGetCustomer(ByVal customerID As Integer, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
        
        Function EndGetCustomer(ByVal result As System.IAsyncResult) As DataClasses.Customer
    End Interface
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface TestServiceChannel
        Inherits ServiceReference1.TestService, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class GetCustomerCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Public Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        Public ReadOnly Property Result() As DataClasses.Customer
            Get
                MyBase.RaiseExceptionIfNecessary
                Return CType(Me.results(0),DataClasses.Customer)
            End Get
        End Property
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class TestServiceClient
        Inherits System.ServiceModel.ClientBase(Of ServiceReference1.TestService)
        Implements ServiceReference1.TestService
        
        Private onBeginGetCustomerDelegate As BeginOperationDelegate
        
        Private onEndGetCustomerDelegate As EndOperationDelegate
        
        Private onGetCustomerCompletedDelegate As System.Threading.SendOrPostCallback
        
        Private onBeginOpenDelegate As BeginOperationDelegate
        
        Private onEndOpenDelegate As EndOperationDelegate
        
        Private onOpenCompletedDelegate As System.Threading.SendOrPostCallback
        
        Private onBeginCloseDelegate As BeginOperationDelegate
        
        Private onEndCloseDelegate As EndOperationDelegate
        
        Private onCloseCompletedDelegate As System.Threading.SendOrPostCallback
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub
        
        Public Property CookieContainer() As System.Net.CookieContainer
            Get
                Dim httpCookieContainerManager As System.ServiceModel.Channels.IHttpCookieContainerManager = Me.InnerChannel.GetProperty(Of System.ServiceModel.Channels.IHttpCookieContainerManager)
                If (Not (httpCookieContainerManager) Is Nothing) Then
                    Return httpCookieContainerManager.CookieContainer
                Else
                    Return Nothing
                End If
            End Get
            Set
                Dim httpCookieContainerManager As System.ServiceModel.Channels.IHttpCookieContainerManager = Me.InnerChannel.GetProperty(Of System.ServiceModel.Channels.IHttpCookieContainerManager)
                If (Not (httpCookieContainerManager) Is Nothing) Then
                    httpCookieContainerManager.CookieContainer = value
                Else
                    Throw New System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC"& _ 
                            "ookieContainerBindingElement.")
                End If
            End Set
        End Property
        
        Public Event GetCustomerCompleted As System.EventHandler(Of GetCustomerCompletedEventArgs)
        
        Public Event OpenCompleted As System.EventHandler(Of System.ComponentModel.AsyncCompletedEventArgs)
        
        Public Event CloseCompleted As System.EventHandler(Of System.ComponentModel.AsyncCompletedEventArgs)
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function ServiceReference1_TestService_BeginGetCustomer(ByVal customerID As Integer, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult Implements ServiceReference1.TestService.BeginGetCustomer
            Return MyBase.Channel.BeginGetCustomer(customerID, callback, asyncState)
        End Function
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function ServiceReference1_TestService_EndGetCustomer(ByVal result As System.IAsyncResult) As DataClasses.Customer Implements ServiceReference1.TestService.EndGetCustomer
            Return MyBase.Channel.EndGetCustomer(result)
        End Function
        
        Private Function OnBeginGetCustomer(ByVal inValues() As Object, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Dim customerID As Integer = CType(inValues(0),Integer)
            Return CType(Me,ServiceReference1.TestService).BeginGetCustomer(customerID, callback, asyncState)
        End Function
        
        Private Function OnEndGetCustomer(ByVal result As System.IAsyncResult) As Object()
            Dim retVal As DataClasses.Customer = CType(Me,ServiceReference1.TestService).EndGetCustomer(result)
            Return New Object() {retVal}
        End Function
        
        Private Sub OnGetCustomerCompleted(ByVal state As Object)
            If (Not (Me.GetCustomerCompletedEvent) Is Nothing) Then
                Dim e As InvokeAsyncCompletedEventArgs = CType(state,InvokeAsyncCompletedEventArgs)
                RaiseEvent GetCustomerCompleted(Me, New GetCustomerCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState))
            End If
        End Sub
        
        Public Overloads Sub GetCustomerAsync(ByVal customerID As Integer)
            Me.GetCustomerAsync(customerID, Nothing)
        End Sub
        
        Public Overloads Sub GetCustomerAsync(ByVal customerID As Integer, ByVal userState As Object)
            If (Me.onBeginGetCustomerDelegate Is Nothing) Then
                Me.onBeginGetCustomerDelegate = AddressOf Me.OnBeginGetCustomer
            End If
            If (Me.onEndGetCustomerDelegate Is Nothing) Then
                Me.onEndGetCustomerDelegate = AddressOf Me.OnEndGetCustomer
            End If
            If (Me.onGetCustomerCompletedDelegate Is Nothing) Then
                Me.onGetCustomerCompletedDelegate = AddressOf Me.OnGetCustomerCompleted
            End If
            MyBase.InvokeAsync(Me.onBeginGetCustomerDelegate, New Object() {customerID}, Me.onEndGetCustomerDelegate, Me.onGetCustomerCompletedDelegate, userState)
        End Sub
        
        Private Function OnBeginOpen(ByVal inValues() As Object, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return CType(Me,System.ServiceModel.ICommunicationObject).BeginOpen(callback, asyncState)
        End Function
        
        Private Function OnEndOpen(ByVal result As System.IAsyncResult) As Object()
            CType(Me,System.ServiceModel.ICommunicationObject).EndOpen(result)
            Return Nothing
        End Function
        
        Private Sub OnOpenCompleted(ByVal state As Object)
            If (Not (Me.OpenCompletedEvent) Is Nothing) Then
                Dim e As InvokeAsyncCompletedEventArgs = CType(state,InvokeAsyncCompletedEventArgs)
                RaiseEvent OpenCompleted(Me, New System.ComponentModel.AsyncCompletedEventArgs(e.[Error], e.Cancelled, e.UserState))
            End If
        End Sub
        
        Public Overloads Sub OpenAsync()
            Me.OpenAsync(Nothing)
        End Sub
        
        Public Overloads Sub OpenAsync(ByVal userState As Object)
            If (Me.onBeginOpenDelegate Is Nothing) Then
                Me.onBeginOpenDelegate = AddressOf Me.OnBeginOpen
            End If
            If (Me.onEndOpenDelegate Is Nothing) Then
                Me.onEndOpenDelegate = AddressOf Me.OnEndOpen
            End If
            If (Me.onOpenCompletedDelegate Is Nothing) Then
                Me.onOpenCompletedDelegate = AddressOf Me.OnOpenCompleted
            End If
            MyBase.InvokeAsync(Me.onBeginOpenDelegate, Nothing, Me.onEndOpenDelegate, Me.onOpenCompletedDelegate, userState)
        End Sub
        
        Private Function OnBeginClose(ByVal inValues() As Object, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return CType(Me,System.ServiceModel.ICommunicationObject).BeginClose(callback, asyncState)
        End Function
        
        Private Function OnEndClose(ByVal result As System.IAsyncResult) As Object()
            CType(Me,System.ServiceModel.ICommunicationObject).EndClose(result)
            Return Nothing
        End Function
        
        Private Sub OnCloseCompleted(ByVal state As Object)
            If (Not (Me.CloseCompletedEvent) Is Nothing) Then
                Dim e As InvokeAsyncCompletedEventArgs = CType(state,InvokeAsyncCompletedEventArgs)
                RaiseEvent CloseCompleted(Me, New System.ComponentModel.AsyncCompletedEventArgs(e.[Error], e.Cancelled, e.UserState))
            End If
        End Sub
        
        Public Overloads Sub CloseAsync()
            Me.CloseAsync(Nothing)
        End Sub
        
        Public Overloads Sub CloseAsync(ByVal userState As Object)
            If (Me.onBeginCloseDelegate Is Nothing) Then
                Me.onBeginCloseDelegate = AddressOf Me.OnBeginClose
            End If
            If (Me.onEndCloseDelegate Is Nothing) Then
                Me.onEndCloseDelegate = AddressOf Me.OnEndClose
            End If
            If (Me.onCloseCompletedDelegate Is Nothing) Then
                Me.onCloseCompletedDelegate = AddressOf Me.OnCloseCompleted
            End If
            MyBase.InvokeAsync(Me.onBeginCloseDelegate, Nothing, Me.onEndCloseDelegate, Me.onCloseCompletedDelegate, userState)
        End Sub
        
        Protected Overrides Function CreateChannel() As ServiceReference1.TestService
            Return New TestServiceClientChannel(Me)
        End Function
        
        Private Class TestServiceClientChannel
            Inherits ChannelBase(Of ServiceReference1.TestService)
            Implements ServiceReference1.TestService
            
            Public Sub New(ByVal client As System.ServiceModel.ClientBase(Of ServiceReference1.TestService))
                MyBase.New(client)
            End Sub
            
            Public Function BeginGetCustomer(ByVal customerID As Integer, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult Implements ServiceReference1.TestService.BeginGetCustomer
                Dim _args((1) - 1) As Object
                _args(0) = customerID
                Dim _result As System.IAsyncResult = MyBase.BeginInvoke("GetCustomer", _args, callback, asyncState)
                Return _result
            End Function
            
            Public Function EndGetCustomer(ByVal result As System.IAsyncResult) As DataClasses.Customer Implements ServiceReference1.TestService.EndGetCustomer
                Dim _args((0) - 1) As Object
                Dim _result As DataClasses.Customer = CType(MyBase.EndInvoke("GetCustomer", _args, result),DataClasses.Customer)
                Return _result
            End Function
        End Class
    End Class
End Namespace