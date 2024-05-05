namespace UniAvatar
{
    public class Animate : IAction
    {
        private readonly AnimationManager _animationManager;

        public Animate(AnimationManager animationManager)
        {
            _animationManager = animationManager;
        }

        public void Execute(string target, string function, string arg3, string arg4, string arg5, System.Action callback)
        {
            _animationManager.PlayAnim(target, function);
        }
    }
}