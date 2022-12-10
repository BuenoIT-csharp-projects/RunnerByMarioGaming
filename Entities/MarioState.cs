/*
 *  Class ID: MarioState
 *  Purpose: To create a Mario state 
 *
 *  Revision history
 *      Sergio Toledo, 2022.12.09: Created and implemented
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunnerByMarioGame.Entities
{
    internal enum MarioState
    {
        Idle,
        Running,
        JumpingUp,
        FallingDown,
        TurningDown,
        NotActive
    }
}
