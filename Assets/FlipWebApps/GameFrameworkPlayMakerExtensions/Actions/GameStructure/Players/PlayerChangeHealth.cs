//----------------------------------------------
// Flip Web Apps: Game Framework
// Copyright � 2016 Flip Web Apps / Mark Hewitt
//
// Please direct any bugs/comments/suggestions to http://www.flipwebapps.com
// 
// The copyright owner grants to the end user a non-exclusive, worldwide, and perpetual license to this Asset
// to integrate only as incorporated and embedded components of electronic games and interactive media and 
// distribute such electronic game and interactive media. End user may modify Assets. End user may otherwise 
// not reproduce, distribute, sublicense, rent, lease or lend the Assets. It is emphasized that the end 
// user shall not be entitled to distribute or transfer in any way (including, without, limitation by way of 
// sublicense) the Assets in any other way than as integrated components of electronic games and interactive media. 

// The above copyright notice and this permission notice must not be removed from any files.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//----------------------------------------------

#if PLAYMAKER
using GameFramework.GameStructure;
using GameFramework.GameStructure.Players;
using HutongGames.PlayMaker;
using UnityEngine.Assertions;

namespace GameFrameworkPlayMakerExtensions.Actions.GameStructure.Players
{
    /// <summary>
    /// Changes the health for the current player.
    /// </summary>
    [ActionCategory("Game Framework")]
    [Tooltip("Changes the health for the current player.")]
    public class PlayerChangeHealth : FsmStateAction
    {
        /// <summary>
        /// The amount by which to change the current health.
        /// </summary>
        [Tooltip("The amount by which to change the current health.")]
        [RequiredField]
        public FsmFloat Amount;

        public override void Reset()
        {
            base.Reset();
            Amount = 0;
        }

        public override void OnEnter()
        {
            PerformAction();
            Finish();
        }

        /// <summary>
        /// The actual method that does the work
        /// </summary>
        void PerformAction()
        {
            Assert.IsTrue(GameManager.IsActive, "Ensure that you have a GameManager added to your scene before using the PlayerChangeHealth action!");

            GameManager.Instance.Player.Health += Amount.Value;
        }
    }
}
#endif