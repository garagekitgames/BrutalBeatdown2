﻿//----------------------------------------------
// Flip Web Apps: Pro Pooling
// Copyright © 2016-2017 Flip Web Apps / Mark Hewitt
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

using UnityEngine;

namespace ProPooling.Components
{
    /// <summary>
    /// Component to reset the transform state when an item is returned to the pool.
    /// </summary>
    [AddComponentMenu("Pro Pooling/On Despawn Reset Transform", 7)]
    [HelpURL("http://www.flipwebapps.com/pro-pooling/")]
    [RequireComponent(typeof(Rigidbody))]
    public class OnDespawnResetTransform : MonoBehaviour, IPoolComponent
    {
        Vector3 _position, _localScale;
        Quaternion _rotation;

        void Awake()
        {
            _position = transform.position;
            _rotation = transform.rotation;
            _localScale = transform.localScale;
        }

        #region IPoolComponent

        public void OnSpawned(PoolItem poolItem) { }

        /// <summary>
        /// Reset transform when despawned back to a pool
        /// </summary>
        /// <param name="poolItem"></param>
        public void OnDespawned(PoolItem poolItem)
        {
            transform.position = _position;
            transform.rotation = _rotation;
            transform.localScale = _localScale;
        }

        #endregion IPoolComponent
    }
}
