namespace UniAvatar
{
    public class Animate : IAction
    {
        private readonly AnimationController _animationController;

        public Animate(AnimationController animationController)
        {
            _animationController = animationController;
        }

        public void Execute(string target, string function, string arg3, string arg4, string arg5, System.Action callback)
        {
            _animationController.PlayAnim(target, function);
        }
    }
}