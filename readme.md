# Project Description
Event Driven 기반의 MSA프로젝트를 진행하면서 작성한 코드 기반으로  
비즈니스 로직을 제거한 소장용 샘플 프로젝트

## EventDriven?
Micro Service Architecture 디자인 중 하나로 서비스간 통신이 이벤트발생에 따라 일어난다.  

기본적으로 Sub/Pub 구조를 가지고 이벤트의 처리가 비동기적인 것이 특징

- 비즈니스 엔터티를 업데이트하는 등 주목할만한 일이 발생할 때 이벤트를 게시  
- 해당 이벤트를 구독하고 있는 서비스에서 수신
- 자체 비즈니스 엔터티를 업데이트 하거나 다른 파생 이벤트 게시

특이점 및 장점  
http, gRPC와 같은 동기 통신 방식의 MSA는 a->b->c 통신이 이루어 질때,  
그 동안 클라이언트는 기다리고 있어야하는 blocking issue 또는 중간의 died service 때문에  
로직의 진행이 멈추어 장애의 전파가 생겨버린다.  

EventDriven은 비동기 통신으로 A -> B의 처리를 기다리지 않는다.  
Message broker가 존재하며 각 서비스에 message를 전달해 주는 역할을 한다.  

broker는 message를 queue로 관리하며 B 서비스가 죽어있어도  
요청이 queue에 남아 나중에 처리 될 수 있다는 장점이 있다.

해당 프로젝트는 Azure ServiceBus를 활용하여 구현하였다.  
외에도 Apache Kafka나 aws SQS, RabbitMQ 등의 솔루션을 이용하여 구현할 수 있다.

## 참고 자료
[MS event-base-communication](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/integration-event-based-microservice-communications)  
[Publish/Subscribe Pattern](https://learn.microsoft.com/en-us/previous-versions/msp-n-p/ff649664(v=pandp.10))  
[MS ServiceBus guide](https://learn.microsoft.com/en-us/azure/service-bus-messaging/service-bus-dotnet-how-to-use-topics-subscriptions?tabs=passwordless)