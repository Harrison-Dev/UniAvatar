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

        [SerializeField] private AnimationManager m_animationManager;
        [SerializeField] private AudioManager m_audioManager;
        [SerializeField] private ChoiceManager m_choiceManager;
        [SerializeField] private DialogueManager m_dialogueManager;
        [SerializeField] private FlagManager m_flagManager;
        [SerializeField] private InputManager m_inputManager;
        [SerializeField] private GameStoryManager m_gameStoryManager;
        [SerializeField] private WordsManager m_wordsManager;
        

        public void Init()
        {
            Container.InjectGameObject(gameObject);
        }

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            builder.RegisterComponent(m_animationManager);
            builder.RegisterComponent(m_audioManager);
            builder.RegisterComponent(m_choiceManager);
            builder.RegisterComponent(m_dialogueManager);
            builder.RegisterComponent(m_flagManager).AsImplementedInterfaces();
            builder.RegisterComponent(m_inputManager);
            builder.RegisterComponent(m_gameStoryManager);
            builder.RegisterComponent(m_wordsManager);
        }

        public void Tick(float dt)
        {

        }


    }
}