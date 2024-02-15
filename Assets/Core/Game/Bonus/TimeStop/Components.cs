namespace Core.Game.Bonus.TimeStop {
    public struct ETimeStop : IEvent { }
    public struct SStopped : IStatus { public float Expired { get; set; } }
}