﻿using Assets._Scripts.Dissonance;
using Synapse.Events.Classes;

namespace Synapse.Events
{
    public static class Events
    {
        //JoinEvent
        public delegate void OnPlayerJoin(ref PlayerJoinClass ev);
        /// <summary>A Event which is activated when a User Joins the Server</summary>
        /// <remarks>It need to hook ref PlayerJoinEvent ev</remarks>
        public static event OnPlayerJoin PlayerJoinEvent;
        internal static void InvokePlayerJoinEvent(ReferenceHub player, ref string nick)
        {
            if (PlayerJoinEvent == null) return;
            var ev = new PlayerJoinClass(player)
            {
                Nick = nick,
            };

            PlayerJoinEvent.Invoke(ref ev);

            nick = ev.Nick;
        }


        //RemoteCommandEvent
        public delegate void OnRemoteCommand(ref RemoteCommandClass ev);
        /// <summary>A Event which is activated when a user send a Command in the Remote Admin</summary>
        /// <remarks>It need to hook ref RemoteCommandEvent ev</remarks>
        public static event OnRemoteCommand RemoteCommandEvent;
        internal static void InvokeRemoteCommandEvent(CommandSender sender, string command, ref bool allow)
        {
            if (RemoteCommandEvent == null) return;

            var ev = new RemoteCommandClass()
            {
                Allow = allow,
                Sender = sender,
                Command = command,
            };

            RemoteCommandEvent.Invoke(ref ev);

            allow = ev.Allow;
        }


        //ConsoleCommandEvent
        public delegate void OnConsoleCommand(ref ConsoleCommandClass ev);
        /// <summary>A Event which is activated when a user send a Command in the Remote Admin</summary>
        public static event OnConsoleCommand ConsoleCommandEvent;
        internal static void InvokeConsoleCommandEvent(ReferenceHub player, string command, out string color, out string returning)
        {
            color = "red";
            returning = "";
            if (ConsoleCommandEvent == null) return;

            var ev = new ConsoleCommandClass()
            {
                Command = command,
                Player = player,
            };

            ConsoleCommandEvent.Invoke(ref ev);

            color = ev.Color;
            returning = ev.ReturnMessage;
        }


        //SpeakEvent
        public delegate void OnSpeak(ref SpeakEventClass ev);
        /// <summary>A Event which is activated when a user press any voice hotkey</summary>
        public static event OnSpeak SpeakEvent;
        internal static void InvokeSpeakEvent(DissonanceUserSetup dissonance, ref bool intercom, ref bool radio, ref bool scp939, ref bool scpchat, ref bool spectator)
        {
            if (SpeakEvent == null) return;

            var ev = new SpeakEventClass()
            {
                IntercomTalk = intercom,
                RadioTalk = radio,
                Scp939Talk = scp939,
                ScpChat = scpchat,
                SpectatorChat = spectator,
                DissonanceUserSetup = dissonance,
                Player = dissonance.gameObject.GetComponent<ReferenceHub>(),
            };

            SpeakEvent.Invoke(ref ev);

            intercom = ev.IntercomTalk;
            radio = ev.RadioTalk;
            scp939 = ev.Scp939Talk;
            scpchat = ev.ScpChat;
            spectator = ev.SpectatorChat;
        }


        //Scp049RecallEvent
        public delegate void OnScp049Recall(ref Scp049RecallClass ev);
        /// <summary>A Event which is activated when Scp049 Recalls a Player</summary>
        public static event OnScp049Recall Scp049RecallEvent;
        internal static void InvokeScp049RecallEvent(ReferenceHub player, ref Ragdoll ragdoll, ref ReferenceHub target, ref bool allow, ref RoleType role, ref float lives)
        {
            if (Scp049RecallEvent == null) return;

            Scp049RecallClass ev = new Scp049RecallClass()
            {
                Allow = allow,
                Ragdoll = ragdoll,
                Target = target,
                RespawnRole = role,
                TargetHealth = lives,
                Player = player
            };

            Scp049RecallEvent.Invoke(ref ev);

            ragdoll = ev.Ragdoll;
            target = ev.Target;
            role = ev.RespawnRole;
            lives = ev.TargetHealth;
            allow = ev.Allow;
        }


        //PlayerLeaveEvent
        public delegate void OnPlayerLeave(PlayerLeaveClass ev);
        /// <summary>
        /// A Event which is activated when a User leave the server
        /// </summary>
        public static event OnPlayerLeave PlayerLeaveEvent;
        internal static void InvokePlayerLeaveEvent(ReferenceHub player)
        {
            if (PlayerLeaveEvent == null) return;

            var ev = new PlayerLeaveClass()
            {
                Player = player,
            };
            PlayerLeaveEvent.Invoke(ev);
        }

        // RoundStartEvent
        public delegate void OnRoundStart();
        public static event OnRoundStart RoundStartEvent;
        internal static void InvokeRoundStart() => RoundStartEvent?.Invoke();


        // PlayerBanEvent
        public delegate void OnPlayerBanEvent(ref PlayerBanClass ev);
        public static event OnPlayerBanEvent PlayerBanEvent;
        internal static void InvokePlayerBanEvent(ReferenceHub player, string userId, int duration, ref bool allow,
            string reason, ReferenceHub issuer)
        {
            if (PlayerBanEvent == null) return;

            var ev = new PlayerBanClass()
            {
                Issuer = issuer,
                Duration = duration,
                Reason = reason,
                BannedPlayer = player,
                UserId = userId
            };

            PlayerBanEvent.Invoke(ref ev);

            allow = ev.Allowed;
        }

        //RoundEndEvent
        public delegate void OnRoundEnd();
        /// <summary>
        /// A Event which activate when the Round Ends (not a Restart!)
        /// </summary>
        public static event OnRoundEnd RoundEndEvent;
        internal static void InvokeRoundEndEvent() => RoundEndEvent?.Invoke();

        //PlayerDieEvent
        public delegate void OnPlayerDeath(PlayerDeathClass ev);
        public static event OnPlayerDeath PlayerDeathEvent;
        internal static void InvokePlayerDieEvent(ReferenceHub player, ReferenceHub killer, PlayerStats.HitInfo infos)
        {
            if (PlayerDeathEvent == null) return;

            var ev = new PlayerDeathClass()
            {
                Info = infos,
                Killer = killer,
                Player = player,
            };

            PlayerDeathEvent.Invoke(ev);
        }

        //PlayerHurtEvent
        public delegate void OnPlayerHurt(ref PlayerHurtClass ev);
        public static event OnPlayerHurt PlayerHurtEvent;
        internal static void InvokePlayerHurtEvent(ReferenceHub player, ReferenceHub attacker, ref PlayerStats.HitInfo info)
        {
            if (PlayerHurtEvent == null) return;

            var ev = new PlayerHurtClass()
            {
                Player = player,
                Attacker = attacker,
                Info = info,
            };

            PlayerHurtEvent.Invoke(ref ev);

            info = ev.Info;
        }

        // RoundRestartEvent
        public delegate void OnRoundRestart();
        public static event OnRoundRestart RoundRestartEvent;
        internal static void InvokeRoundRestart() => RoundRestartEvent?.Invoke();

        // DoorInteractEvent
        public delegate void OnDoorInteract(ref DoorInteractClass ev);
        public static event OnDoorInteract DoorInteractEvent;
        internal static void InvokeDoorInteraction(ReferenceHub player, Door door, ref bool allow)
        {
            if (DoorInteractEvent == null) return;

            var ev = new DoorInteractClass()
            {
                Player = player,
                Allow = allow,
                Door = door
            };
            
            DoorInteractEvent.Invoke(ref ev);

            allow = ev.Allow;
        }

        //PlayerCuffedEvent
        public delegate void OnPlayerCuffed(ref PlayerCuffedClass ev);
        public static event OnPlayerCuffed PlayerCuffedEvent;
        internal static void InvokePlayerCuffedEvent(ReferenceHub cuffer, ReferenceHub target, ref bool allow)
        {
            if (PlayerCuffedEvent == null) return;

            var ev = new PlayerCuffedClass()
            {
                Cuffer = cuffer,
                Target = target,
                Allow = allow,
            };

            PlayerCuffedEvent.Invoke(ref ev);

            allow = ev.Allow;
        }
    }
}