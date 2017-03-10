using System;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace KyoshinShindoPlaceEditor
{
	internal class InterpolatedPictureBox : PictureBox
	{
		private InterpolationMode _interpolation = InterpolationMode.Default;

		[DefaultValue(typeof(InterpolationMode), "NearestNeighbor"), Description("画像の拡大縮小に使用するアルゴリズムを指定します。")]
		public InterpolationMode Interpolation
		{
			get => _interpolation;
			set
			{
				if (value == InterpolationMode.Invalid)
					throw new ArgumentException("\"Invalid\" is not a valid value."); // (Duh!)

				_interpolation = value;
				Invalidate(); // Image should be redrawn when a different interpolation is selected
			}
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			pe.Graphics.InterpolationMode = _interpolation;
			pe.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
			base.OnPaint(pe);
		}
	}
}