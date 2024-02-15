using System.Collections.Generic;
using System.Linq;
using Core.Common;
using Core.Common.Data;
using Core.Common.Utils;
using Core.Game.Common;
using Core.Game.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.Game.Exodus {
    public class ExodusService : IInitializable {
        [Inject] private RuntimeData Data { get; set; }
        [Inject] private GeneralConfig Configs { get; set; }
        [Inject] private LevelContext Context { get; set; }
        [Inject] private MusicService Music { get; set; }

        public bool Has => Status != ExodusID.None;
        private Dictionary<ExodusID, ExodusStateData> States { get; set; }
        private ExodusID Status { get; set; } = ExodusID.None;
        public Observable<string> Title { get; } = new("---");
        public Observable<string> Message { get; } = new("---");
        public Observable<Color> MessageColor { get; } = new(Color.white);


        public void Initialize() =>
            States = Configs.exodus.states.ToDictionary(x => x.id, x => x);

        public void Declare(ExodusID type) {
            Status = type;
            Title.Value = States[type].title;
            Message.Value = States[type].message;
            MessageColor.Value = States[type].messageColor;
            Data.Player = null;
            Time.timeScale = 0;

            Context.ui.Show(ViewID.DefeatModal);
            // Music.Play(States[type].jingle);
            Debug.Log($"=== {type} ===");
        }
    }
}