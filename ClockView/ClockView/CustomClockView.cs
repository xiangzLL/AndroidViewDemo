using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Util;
using static Android.Graphics.Paint;

namespace ClockView
{
    //https://blog.csdn.net/u012702547/article/details/51030141
    public class CustomClockView:View
    {
        private Paint circlePaint;

        private Paint numPaint;

        private Paint dotPaint;

        private Paint hourPaint;

        private Paint minutePaint;

        private Paint secondPaint;

        //View的宽度
        private int width;
        //View的高度
        private int height;

        //获取当前时间
        private Calendar calendar;
        
        private Color hourColor;

        private Color minuteColor;

        private Color secondColor;

        private int hourWidth;

        private int minuteWidth;

        private int secondWidth;

        public CustomClockView(Context context) : this(context,null)
        {
            
        }

        public CustomClockView(Context context, IAttributeSet attrs) : this(context, attrs,0)
        {
        }

        public CustomClockView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            InitView();
        }

        private void InitView()
        {
            calendar = Calendar.Instance;
            width = (int) TypedValue.ApplyDimension(ComplexUnitType.Dip, 256, new DisplayMetrics());
            height = (int) TypedValue.ApplyDimension(ComplexUnitType.Dip, 256, new DisplayMetrics());

            hourColor = Color.Red;
            minuteColor = Color.Green;
            secondColor = Color.Blue;

            hourWidth = 8;
            minuteWidth = 5;
            secondWidth = 2;

            circlePaint = new Paint
            {
                AntiAlias = true,
                Color = Color.Green,
                StrokeWidth = 6
            };
            circlePaint.SetStyle(Style.Stroke);

            dotPaint = new Paint
            {
                AntiAlias = true,
                Color = Color.Red
            };
            dotPaint.SetStyle(Style.Fill);

            numPaint = new Paint
            {
                AntiAlias = true,
                Color = Color.Red,
                TextAlign = Align.Center
            };

            hourPaint = new Paint
            {
                Color = hourColor,
                StrokeWidth = hourWidth
            };
            hourPaint.SetStyle(Style.Fill);

            hourPaint = new Paint
            {
                Color = hourColor,
                StrokeWidth = hourWidth
            };
            hourPaint.SetStyle(Style.Fill);

            minutePaint = new Paint
            {
                Color = minuteColor,
                StrokeWidth = minuteWidth
            };
            minutePaint.SetStyle(Style.Fill);

            secondPaint = new Paint
            {
                Color = secondColor,
                StrokeWidth = secondWidth
            };
            secondPaint.SetStyle(Style.Fill);
        }

        protected override void OnDraw(Canvas canvas)
        {
            calendar = Calendar.Instance;
            var radius = width / 2 - 10;
            canvas.DrawCircle((float)width/2,(float)height/2,radius,circlePaint);

            canvas.DrawCircle((float)width / 2, (float)height / 2, 15, dotPaint);

            for (var i = 1; i < 13; i++)
            {
                canvas.Save();
                canvas.Rotate(i * 30, (float) width / 2, (float) height / 2);
                canvas.DrawLine((float) width / 2, height / 2 - radius, (float) width / 2, height / 2 - radius + 10,
                    circlePaint);
                canvas.DrawText(i+"", (float)width / 2, height / 2 - radius + 22, numPaint);

                canvas.Restore();
            }

            var hour = calendar.Get(CalendarField.Hour);
        }
    }
}