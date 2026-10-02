using Pangya_GameServer.Roms.GameBase.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pangya_GameServer.Models
{
    public class RoomGrandPrixInstanciaCtx
    {
        public enum eSTATE : byte
        {
            GOOD,
            DESTROYING,
            DESTROYED
        }

        public RoomGrandPrixInstanciaCtx(RoomGrandPrix _rgp, eSTATE _state)
        {
            this.m_rgp = _rgp;
            this.m_state = _state;
        }

        public RoomGrandPrix m_rgp;
        public eSTATE m_state = new eSTATE();
    }

    public class CriticalSectionInstancia
    {
        public CriticalSectionInstancia()
        {
            this.m_state = false;
            this.m_lock = false;

            init();

        }

        public void init()
        {

            if (!m_state)
            {
            }

            m_state = true;
        }

        public void @lock()
        {

            if (!m_state)
            {
                init();
            }

            //Monitor.Exit(m_cs);
            // Est  bloqueado
            m_lock = true;

        }

        public void unlock()
        {

            if (!m_lock)
            {
                return; // N o est  bloqueado
            }

            // Desbloquea
            m_lock = false;

            //Monitor.Exit(m_cs);
        }

        public object m_cs { get; set; } = new object();
        public bool m_state { get; set; }
        public bool m_lock { get; set; }
    }
}
