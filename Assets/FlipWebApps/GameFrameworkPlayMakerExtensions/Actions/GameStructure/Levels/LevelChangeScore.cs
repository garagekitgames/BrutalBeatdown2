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
using GameFramework.GameStructure.Levels;
using HutongGames.PlayMaker;
using UnityEngine.Assertions;

namespace GameFrameworkPlayMakerExtensions.Actions.GameStructure.Levels
{
    /// <summary>
    /// Changes the score for the current level.
    /// </summary>
    [ActionCategory("Game Framework")]
    [Tooltip("Changes the score for the current level.")]
    public class LevelChangeScore : FsmStateAction
    {
        /// <summary>
        /// The amount by which to change the current score.
        /// </summary>
        [Tooltip("The amount by which to change the current score.")]
        [RequiredField]
        public FsmInt Amount;

        public override void Reset()
        {
            base.Reset();
            //Amount = new FsmInt { UseVariable = false, Value = 0};
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
            Assert.IsTrue(LevelManager.IsActive, "Ensure that you have a LevelManager added to your scene before using the LevelChangeScore action!");

            LevelManager.Instance.Level.Score += Amount.Value;
        }
    }
}
#endif