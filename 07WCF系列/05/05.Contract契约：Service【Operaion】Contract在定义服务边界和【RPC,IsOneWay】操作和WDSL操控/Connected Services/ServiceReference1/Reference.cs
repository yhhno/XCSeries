﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _05.Contract契约_Service_Operaion_Contract在定义服务边界和_RPC_IsOneWay_操作和WDSL操控.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IHomeService")]
    public interface IHomeService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHomeService/DoWork", ReplyAction="http://tempuri.org/IHomeService/DoWorkResponse")]
        void DoWork(string msg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHomeService/DoWork", ReplyAction="http://tempuri.org/IHomeService/DoWorkResponse")]
        System.Threading.Tasks.Task DoWorkAsync(string msg);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IHomeServiceChannel : _05.Contract契约_Service_Operaion_Contract在定义服务边界和_RPC_IsOneWay_操作和WDSL操控.ServiceReference1.IHomeService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class HomeServiceClient : System.ServiceModel.ClientBase<_05.Contract契约_Service_Operaion_Contract在定义服务边界和_RPC_IsOneWay_操作和WDSL操控.ServiceReference1.IHomeService>, _05.Contract契约_Service_Operaion_Contract在定义服务边界和_RPC_IsOneWay_操作和WDSL操控.ServiceReference1.IHomeService {
        
        public HomeServiceClient() {
        }
        
        public HomeServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public HomeServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HomeServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HomeServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DoWork(string msg) {
            base.Channel.DoWork(msg);
        }
        
        public System.Threading.Tasks.Task DoWorkAsync(string msg) {
            return base.Channel.DoWorkAsync(msg);
        }
    }
}
