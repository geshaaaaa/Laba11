using produce_consumer;

PRODUCER_CONSUMER PC = new PRODUCER_CONSUMER();

Thread producer = new Thread(PC.Produce);
Thread consumer = new Thread(PC.Consume);   
producer.Start();
consumer.Start();
producer.Join();    
consumer.Join();