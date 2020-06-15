namespace Actor.Enemy
{
    public class EnemyData : ActorData {
        
        protected override bool IsDead() => Health > 0;
    }
}