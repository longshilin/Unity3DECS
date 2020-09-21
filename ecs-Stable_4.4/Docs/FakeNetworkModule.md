# Fake NetworkModule source code
Here are some classes for understanding how to set up **NetworkModule** properly. You should replace FakeTransporter and FakeSerializer with your implementation.
Local project will run and all RPC events will go through NetworkModule.

> Note: FakeSerializer depends on [FullSerializer](https://github.com/jacobdufault/fullserializer).

```csharp
public class NetworkModule : ME.ECS.Network.NetworkModule<State> {

    protected override int GetRPCOrder() {

        // TODO: Place here your Network Player Id
        return this.world.id;

    }

    protected override ME.ECS.Network.NetworkType GetNetworkType() {

        // You can remove RunLocal parameter to avoid run events on local machine immediately.
        // This behaviour depends on your needs, because in some projects you need to run all user events smoothly without any delay like a ping or awaiting of server logic.
        return ME.ECS.Network.NetworkType.SendToNet | ME.ECS.Network.NetworkType.RunLocal;

    }

    protected override void OnInitialize() {

        // Here you need to set up transporter and serializer classes
        var instance = (ME.ECS.Network.INetworkModuleBase)this;
        instance.SetTransporter(new FakeTransporter(this.GetNetworkType()));
        instance.SetSerializer(new FakeSerializer());

    }

}

public class FakeTransporter : ME.ECS.Network.ITransporter {

    private struct Buffer {

        public byte[] data;

    }

    private readonly System.Collections.Generic.Queue<Buffer> buffers = new System.Collections.Generic.Queue<Buffer>();
    private readonly ME.ECS.Network.NetworkType networkType;
    private int sentCount;
    private int sentBytesCount;
    private int receivedCount;
    private int receivedBytesCount;
    private double ping;

    public FakeTransporter(ME.ECS.Network.NetworkType networkType) {

        this.networkType = networkType;

    }

    public void Send(byte[] bytes) {

        if ((this.networkType & ME.ECS.Network.NetworkType.RunLocal) == 0) {
        
            // Add to local buffer if RunLocal flag is not set.
            // If flag RunLocal is set, this event has been run already.
            // This is FakeTransporter behaviour only.
            this.AddToBuffer(bytes);

        }

        // TODO: Here you need to send bytes array via your real transport layer to test real network environment.
        
        this.sentBytesCount += bytes.Length;
        ++this.sentCount;

    }

    private void AddToBuffer(byte[] bytes) {

        this.buffers.Enqueue(new Buffer() {
            data = bytes,
        });

    }

    private Buffer currentBuffer;

    public byte[] Receive() {

        // This method run every tick and should return data from network
        // byte[] array will be deserialized by ISerializer into HistoryEvent

        if (this.currentBuffer.data != null && this.currentBuffer.data.Length > 0) {

            this.receivedBytesCount += this.currentBuffer.data.Length;
            ++this.receivedCount;
            return this.currentBuffer.data;

        }

        if (this.buffers.Count > 0) {

            var buffer = this.buffers.Dequeue();
            this.currentBuffer = buffer;

        }

        return null;

    }

    public int GetEventsSentCount() {

        return this.sentCount;

    }

    public int GetEventsBytesSentCount() {

        return this.sentBytesCount;

    }

    public int GetEventsReceivedCount() {

        return this.receivedCount;

    }

    public int GetEventsBytesReceivedCount() {
        
        return this.receivedBytesCount;
        
    }

}

public class FakeSerializer : ME.ECS.Network.ISerializer {

    private readonly FullSerializer.fsSerializer fsSerializer = new FullSerializer.fsSerializer();

    public byte[] SerializeStorage(ME.ECS.StatesHistory.HistoryStorage historyEvent) {

        FullSerializer.fsData data;
        this.fsSerializer.TrySerialize(typeof(ME.ECS.StatesHistory.HistoryStorage), historyEvent, out data).AssertSuccessWithoutWarnings();
        var str = FullSerializer.fsJsonPrinter.CompressedJson(data);
        return System.Text.Encoding.UTF8.GetBytes(str);

    }

    public ME.ECS.StatesHistory.HistoryStorage DeserializeStorage(byte[] bytes) {

        var fsData = System.Text.Encoding.UTF8.GetString(bytes);
        FullSerializer.fsData data = FullSerializer.fsJsonParser.Parse(fsData);
        object deserialized = null;
        this.fsSerializer.TryDeserialize(data, typeof(ME.ECS.StatesHistory.HistoryStorage), ref deserialized).AssertSuccessWithoutWarnings();

        return (ME.ECS.StatesHistory.HistoryStorage)deserialized;

    }

    public byte[] Serialize(ME.ECS.StatesHistory.HistoryEvent historyEvent) {

        FullSerializer.fsData data;
        this.fsSerializer.TrySerialize(typeof(ME.ECS.StatesHistory.HistoryEvent), historyEvent, out data).AssertSuccessWithoutWarnings();
        var str = FullSerializer.fsJsonPrinter.CompressedJson(data);
        return System.Text.Encoding.UTF8.GetBytes(str);

    }

    public ME.ECS.StatesHistory.HistoryEvent Deserialize(byte[] bytes) {

        var fsData = System.Text.Encoding.UTF8.GetString(bytes);
        FullSerializer.fsData data = FullSerializer.fsJsonParser.Parse(fsData);
        object deserialized = null;
        this.fsSerializer.TryDeserialize(data, typeof(ME.ECS.StatesHistory.HistoryEvent), ref deserialized).AssertSuccessWithoutWarnings();

        return (ME.ECS.StatesHistory.HistoryEvent)deserialized;

    }

}
```

[![](Footer.png)](/../../#glossary)
