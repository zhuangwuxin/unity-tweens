using ElRaccoone.Tweens.Core;
using UnityEngine;

namespace ElRaccoone.Tweens {
  public static class LocalPositionTween {
    public static Tween<Vector3> TweenLocalPosition (this Component self, Vector3 to, float duration) =>
      Tween<Vector3>.Add<Driver> (self).Finalize (duration, to);

    public static Tween<Vector3> TweenLocalPosition (this GameObject self, Vector3 to, float duration) =>
      Tween<Vector3>.Add<Driver> (self).Finalize (duration, to);

    private class Driver : Tween<Vector3, Transform> {
      public override Vector3 OnGetFrom () {
        return this.component.localPosition;
      }

      public override void OnUpdate (float easedTime) {
        this.valueCurrent.x = this.InterpolateValue (this.valueFrom.x, this.valueTo.x, easedTime);
        this.valueCurrent.y = this.InterpolateValue (this.valueFrom.y, this.valueTo.y, easedTime);
        this.valueCurrent.z = this.InterpolateValue (this.valueFrom.z, this.valueTo.z, easedTime);
        this.component.localPosition = this.valueCurrent;
      }
    }
  }
}