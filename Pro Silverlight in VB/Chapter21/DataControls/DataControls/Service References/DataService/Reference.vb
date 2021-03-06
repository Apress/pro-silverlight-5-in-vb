﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.237
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
Namespace DataService
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute([Namespace]:="", ConfigurationName:="DataService.StoreDb")>  _
    Public Interface StoreDb
        
        <System.ServiceModel.OperationContractAttribute(AsyncPattern:=true, Action:="urn:StoreDb/GetProduct", ReplyAction:="urn:StoreDb/GetProductResponse")>  _
        Function BeginGetProduct(ByVal ID As Integer, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
        
        Function EndGetProduct(ByVal result As System.IAsyncResult) As StoreDbDataClasses.Product
        
        <System.ServiceModel.OperationContractAttribute(AsyncPattern:=true, Action:="urn:StoreDb/GetProducts", ReplyAction:="urn:StoreDb/GetProductsResponse")>  _
        Function BeginGetProducts(ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
        
        Function EndGetProducts(ByVal result As System.IAsyncResult) As System.Collections.ObjectModel.ObservableCollection(Of StoreDbDataClasses.Product)
        
        <System.ServiceModel.OperationContractAttribute(AsyncPattern:=true, Action:="urn:StoreDb/GetCategoriesWithProducts", ReplyAction:="urn:StoreDb/GetCategoriesWithProductsResponse")>  _
        Function BeginGetCategoriesWithProducts(ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
        
        Function EndGetCategoriesWithProducts(ByVal result As System.IAsyncResult) As System.Collections.ObjectModel.ObservableCollection(Of StoreDbDataClasses.Category)
    End Interface
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface StoreDbChannel
        Inherits DataService.StoreDb, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class GetProductCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Public Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        Public ReadOnly Property Result() As StoreDbDataClasses.Product
            Get
                MyBase.RaiseExceptionIfNecessary
                Return CType(Me.results(0),StoreDbDataClasses.Product)
            End Get
        End Property
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class GetProductsCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Public Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        Public ReadOnly Property Result() As System.Collections.ObjectModel.ObservableCollection(Of StoreDbDataClasses.Product)
            Get
                MyBase.RaiseExceptionIfNecessary
                Return CType(Me.results(0),System.Collections.ObjectModel.ObservableCollection(Of StoreDbDataClasses.Product))
            End Get
        End Property
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class GetCategoriesWithProductsCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Public Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        Public ReadOnly Property Result() As System.Collections.ObjectModel.ObservableCollection(Of StoreDbDataClasses.Category)
            Get
                MyBase.RaiseExceptionIfNecessary
                Return CType(Me.results(0),System.Collections.ObjectModel.ObservableCollection(Of StoreDbDataClasses.Category))
            End Get
        End Property
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class StoreDbClient
        Inherits System.ServiceModel.ClientBase(Of DataService.StoreDb)
        Implements DataService.StoreDb
        
        Private onBeginGetProductDelegate As BeginOperationDelegate
        
        Private onEndGetProductDelegate As EndOperationDelegate
        
        Private onGetProductCompletedDelegate As System.Threading.SendOrPostCallback
        
        Private onBeginGetProductsDelegate As BeginOperationDelegate
        
        Private onEndGetProductsDelegate As EndOperationDelegate
        
        Private onGetProductsCompletedDelegate As System.Threading.SendOrPostCallback
        
        Private onBeginGetCategoriesWithProductsDelegate As BeginOperationDelegate
        
        Private onEndGetCategoriesWithProductsDelegate As EndOperationDelegate
        
        Private onGetCategoriesWithProductsCompletedDelegate As System.Threading.SendOrPostCallback
        
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
        
        Public Event GetProductCompleted As System.EventHandler(Of GetProductCompletedEventArgs)
        
        Public Event GetProductsCompleted As System.EventHandler(Of GetProductsCompletedEventArgs)
        
        Public Event GetCategoriesWithProductsCompleted As System.EventHandler(Of GetCategoriesWithProductsCompletedEventArgs)
        
        Public Event OpenCompleted As System.EventHandler(Of System.ComponentModel.AsyncCompletedEventArgs)
        
        Public Event CloseCompleted As System.EventHandler(Of System.ComponentModel.AsyncCompletedEventArgs)
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function DataService_StoreDb_BeginGetProduct(ByVal ID As Integer, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult Implements DataService.StoreDb.BeginGetProduct
            Return MyBase.Channel.BeginGetProduct(ID, callback, asyncState)
        End Function
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function DataService_StoreDb_EndGetProduct(ByVal result As System.IAsyncResult) As StoreDbDataClasses.Product Implements DataService.StoreDb.EndGetProduct
            Return MyBase.Channel.EndGetProduct(result)
        End Function
        
        Private Function OnBeginGetProduct(ByVal inValues() As Object, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Dim ID As Integer = CType(inValues(0),Integer)
            Return CType(Me,DataService.StoreDb).BeginGetProduct(ID, callback, asyncState)
        End Function
        
        Private Function OnEndGetProduct(ByVal result As System.IAsyncResult) As Object()
            Dim retVal As StoreDbDataClasses.Product = CType(Me,DataService.StoreDb).EndGetProduct(result)
            Return New Object() {retVal}
        End Function
        
        Private Sub OnGetProductCompleted(ByVal state As Object)
            If (Not (Me.GetProductCompletedEvent) Is Nothing) Then
                Dim e As InvokeAsyncCompletedEventArgs = CType(state,InvokeAsyncCompletedEventArgs)
                RaiseEvent GetProductCompleted(Me, New GetProductCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState))
            End If
        End Sub
        
        Public Overloads Sub GetProductAsync(ByVal ID As Integer)
            Me.GetProductAsync(ID, Nothing)
        End Sub
        
        Public Overloads Sub GetProductAsync(ByVal ID As Integer, ByVal userState As Object)
            If (Me.onBeginGetProductDelegate Is Nothing) Then
                Me.onBeginGetProductDelegate = AddressOf Me.OnBeginGetProduct
            End If
            If (Me.onEndGetProductDelegate Is Nothing) Then
                Me.onEndGetProductDelegate = AddressOf Me.OnEndGetProduct
            End If
            If (Me.onGetProductCompletedDelegate Is Nothing) Then
                Me.onGetProductCompletedDelegate = AddressOf Me.OnGetProductCompleted
            End If
            MyBase.InvokeAsync(Me.onBeginGetProductDelegate, New Object() {ID}, Me.onEndGetProductDelegate, Me.onGetProductCompletedDelegate, userState)
        End Sub
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function DataService_StoreDb_BeginGetProducts(ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult Implements DataService.StoreDb.BeginGetProducts
            Return MyBase.Channel.BeginGetProducts(callback, asyncState)
        End Function
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function DataService_StoreDb_EndGetProducts(ByVal result As System.IAsyncResult) As System.Collections.ObjectModel.ObservableCollection(Of StoreDbDataClasses.Product) Implements DataService.StoreDb.EndGetProducts
            Return MyBase.Channel.EndGetProducts(result)
        End Function
        
        Private Function OnBeginGetProducts(ByVal inValues() As Object, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return CType(Me,DataService.StoreDb).BeginGetProducts(callback, asyncState)
        End Function
        
        Private Function OnEndGetProducts(ByVal result As System.IAsyncResult) As Object()
            Dim retVal As System.Collections.ObjectModel.ObservableCollection(Of StoreDbDataClasses.Product) = CType(Me,DataService.StoreDb).EndGetProducts(result)
            Return New Object() {retVal}
        End Function
        
        Private Sub OnGetProductsCompleted(ByVal state As Object)
            If (Not (Me.GetProductsCompletedEvent) Is Nothing) Then
                Dim e As InvokeAsyncCompletedEventArgs = CType(state,InvokeAsyncCompletedEventArgs)
                RaiseEvent GetProductsCompleted(Me, New GetProductsCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState))
            End If
        End Sub
        
        Public Overloads Sub GetProductsAsync()
            Me.GetProductsAsync(Nothing)
        End Sub
        
        Public Overloads Sub GetProductsAsync(ByVal userState As Object)
            If (Me.onBeginGetProductsDelegate Is Nothing) Then
                Me.onBeginGetProductsDelegate = AddressOf Me.OnBeginGetProducts
            End If
            If (Me.onEndGetProductsDelegate Is Nothing) Then
                Me.onEndGetProductsDelegate = AddressOf Me.OnEndGetProducts
            End If
            If (Me.onGetProductsCompletedDelegate Is Nothing) Then
                Me.onGetProductsCompletedDelegate = AddressOf Me.OnGetProductsCompleted
            End If
            MyBase.InvokeAsync(Me.onBeginGetProductsDelegate, Nothing, Me.onEndGetProductsDelegate, Me.onGetProductsCompletedDelegate, userState)
        End Sub
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function DataService_StoreDb_BeginGetCategoriesWithProducts(ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult Implements DataService.StoreDb.BeginGetCategoriesWithProducts
            Return MyBase.Channel.BeginGetCategoriesWithProducts(callback, asyncState)
        End Function
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function DataService_StoreDb_EndGetCategoriesWithProducts(ByVal result As System.IAsyncResult) As System.Collections.ObjectModel.ObservableCollection(Of StoreDbDataClasses.Category) Implements DataService.StoreDb.EndGetCategoriesWithProducts
            Return MyBase.Channel.EndGetCategoriesWithProducts(result)
        End Function
        
        Private Function OnBeginGetCategoriesWithProducts(ByVal inValues() As Object, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return CType(Me,DataService.StoreDb).BeginGetCategoriesWithProducts(callback, asyncState)
        End Function
        
        Private Function OnEndGetCategoriesWithProducts(ByVal result As System.IAsyncResult) As Object()
            Dim retVal As System.Collections.ObjectModel.ObservableCollection(Of StoreDbDataClasses.Category) = CType(Me,DataService.StoreDb).EndGetCategoriesWithProducts(result)
            Return New Object() {retVal}
        End Function
        
        Private Sub OnGetCategoriesWithProductsCompleted(ByVal state As Object)
            If (Not (Me.GetCategoriesWithProductsCompletedEvent) Is Nothing) Then
                Dim e As InvokeAsyncCompletedEventArgs = CType(state,InvokeAsyncCompletedEventArgs)
                RaiseEvent GetCategoriesWithProductsCompleted(Me, New GetCategoriesWithProductsCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState))
            End If
        End Sub
        
        Public Overloads Sub GetCategoriesWithProductsAsync()
            Me.GetCategoriesWithProductsAsync(Nothing)
        End Sub
        
        Public Overloads Sub GetCategoriesWithProductsAsync(ByVal userState As Object)
            If (Me.onBeginGetCategoriesWithProductsDelegate Is Nothing) Then
                Me.onBeginGetCategoriesWithProductsDelegate = AddressOf Me.OnBeginGetCategoriesWithProducts
            End If
            If (Me.onEndGetCategoriesWithProductsDelegate Is Nothing) Then
                Me.onEndGetCategoriesWithProductsDelegate = AddressOf Me.OnEndGetCategoriesWithProducts
            End If
            If (Me.onGetCategoriesWithProductsCompletedDelegate Is Nothing) Then
                Me.onGetCategoriesWithProductsCompletedDelegate = AddressOf Me.OnGetCategoriesWithProductsCompleted
            End If
            MyBase.InvokeAsync(Me.onBeginGetCategoriesWithProductsDelegate, Nothing, Me.onEndGetCategoriesWithProductsDelegate, Me.onGetCategoriesWithProductsCompletedDelegate, userState)
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
        
        Protected Overrides Function CreateChannel() As DataService.StoreDb
            Return New StoreDbClientChannel(Me)
        End Function
        
        Private Class StoreDbClientChannel
            Inherits ChannelBase(Of DataService.StoreDb)
            Implements DataService.StoreDb
            
            Public Sub New(ByVal client As System.ServiceModel.ClientBase(Of DataService.StoreDb))
                MyBase.New(client)
            End Sub
            
            Public Function BeginGetProduct(ByVal ID As Integer, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult Implements DataService.StoreDb.BeginGetProduct
                Dim _args((1) - 1) As Object
                _args(0) = ID
                Dim _result As System.IAsyncResult = MyBase.BeginInvoke("GetProduct", _args, callback, asyncState)
                Return _result
            End Function
            
            Public Function EndGetProduct(ByVal result As System.IAsyncResult) As StoreDbDataClasses.Product Implements DataService.StoreDb.EndGetProduct
                Dim _args((0) - 1) As Object
                Dim _result As StoreDbDataClasses.Product = CType(MyBase.EndInvoke("GetProduct", _args, result),StoreDbDataClasses.Product)
                Return _result
            End Function
            
            Public Function BeginGetProducts(ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult Implements DataService.StoreDb.BeginGetProducts
                Dim _args((0) - 1) As Object
                Dim _result As System.IAsyncResult = MyBase.BeginInvoke("GetProducts", _args, callback, asyncState)
                Return _result
            End Function
            
            Public Function EndGetProducts(ByVal result As System.IAsyncResult) As System.Collections.ObjectModel.ObservableCollection(Of StoreDbDataClasses.Product) Implements DataService.StoreDb.EndGetProducts
                Dim _args((0) - 1) As Object
                Dim _result As System.Collections.ObjectModel.ObservableCollection(Of StoreDbDataClasses.Product) = CType(MyBase.EndInvoke("GetProducts", _args, result),System.Collections.ObjectModel.ObservableCollection(Of StoreDbDataClasses.Product))
                Return _result
            End Function
            
            Public Function BeginGetCategoriesWithProducts(ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult Implements DataService.StoreDb.BeginGetCategoriesWithProducts
                Dim _args((0) - 1) As Object
                Dim _result As System.IAsyncResult = MyBase.BeginInvoke("GetCategoriesWithProducts", _args, callback, asyncState)
                Return _result
            End Function
            
            Public Function EndGetCategoriesWithProducts(ByVal result As System.IAsyncResult) As System.Collections.ObjectModel.ObservableCollection(Of StoreDbDataClasses.Category) Implements DataService.StoreDb.EndGetCategoriesWithProducts
                Dim _args((0) - 1) As Object
                Dim _result As System.Collections.ObjectModel.ObservableCollection(Of StoreDbDataClasses.Category) = CType(MyBase.EndInvoke("GetCategoriesWithProducts", _args, result),System.Collections.ObjectModel.ObservableCollection(Of StoreDbDataClasses.Category))
                Return _result
            End Function
        End Class
    End Class
End Namespace
