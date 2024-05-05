using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace UniAvatar
{
    // Dummy entry, for single usage.
    public class UniAvatarEntry : LifetimeScope
    {
        protected override void Awake() 
        {
            base.Awake();
            Init();
        }
        private void Update() => Tick(Time.deltaTime);

        [SerializeField] private AnimationController m_animationController;
        [SerializeField] private AudioController m_audioController;
        [SerializeField] private ChoiceController m_choiceController;
        [SerializeField] private DialogueController m_dialogueController;
        [SerializeField] private FlagController m_flagController;
        [SerializeField] private InputController m_inputController;
        [SerializeField] private GameStoryController m_gameStoryController;
        [SerializeField] private WordsController m_wordsController;
        

        public void Init()
        {
            Container.InjectGameObject(gameObject);
        }

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            builder.RegisterComponent(m_animationController);
            builder.RegisterComponent(m_audioController);
            builder.RegisterComponent(m_choiceController);
            builder.RegisterComponent(m_dialogueController);
            builder.RegisterComponent(m_flagController).AsImplementedInterfaces();
            builder.RegisterComponent(m_inputController);
            builder.RegisterComponent(m_gameStoryController);
            builder.RegisterComponent(m_wordsController);
        }

        public void Tick(float dt)
        {

        }


    }
}