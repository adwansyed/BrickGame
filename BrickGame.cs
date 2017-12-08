/// Author: Shiva Bhardwaj
/// Brick Game. 

using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace BrickGame
{
    class BrickGame
    {
        private Brush _pixel = new SolidBrush(Color.White); //player colour definition
        private Brush _scorePixel = new SolidBrush(Color.White);
        private PictureBox _window;
        private Pixel _ball;
        private Direction _ballDirection = Direction.RightUp;
        private Pixel _player1;
        private Pixel block;
        private Pixel fire;
        Random block_x = new Random();                        //blocks x change position
        Random block_y = new Random();                        // blocks y change position
        Random block_color = new Random();                   // random colour definition  
        Color block_change;                                // so that the colours are changed everytime it hits
        int points;                                           
        bool hit = false;
        bool onfire = false;

        public BrickGame(PictureBox window)
        {
            _window = window;

            set();

            _window.MouseMove += windowMouseMove;
            _window.Paint += windowPixels;
        }

        private void set()
        {
            Color randomColor = RandomColor();
            _player1 = new Pixel(125, 300, 75, 15, Color.White);
            block = new Pixel(45,100 , 75, 15, randomColor);
            _ball = new Pixel((_window.Width / 2) - 25, (_window.Height / 2) - 25, 25, 25, Color.White);
            _ballDirection = Direction.RightUp;
            fire = new Pixel(0, 340, 525, 4, Color.Navy);
        }
        private void blockrelocate()
        {
            points++;
            int bx = block_x.Next(0,450);
            int by = block_y.Next(0,300);
            block_change = RandomColor();
            block = new Pixel(bx, by, 75, 15, block_change);
        }
        private Color RandomColor()
        {
           return Color.FromArgb(block_color.Next(0, 255), block_color.Next(0, 255), block_color.Next(0, 255));
        }
       
        private void windowMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Location.X > 0 && e.Location.X <= (_window.Width - _player1.Width))
                _player1.X = e.Location.X;
        }

       


       
        private void windowPixels(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString(string.Format("Score: {0}", points), new Font(FontFamily.GenericSansSerif, 18), _scorePixel, 190, 10);
                        
            e.Graphics.FillRectangle(_pixel, _player1.ToRectangle());
            if (hit == true)
            {
                Brush _pixel2 = new SolidBrush(block_change);
                e.Graphics.FillRectangle(_pixel2, block.ToRectangle());
            }
            else
            {
                Brush _pixel2 = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(_pixel2, block.ToRectangle());
            }
           
            e.Graphics.FillEllipse(_pixel, _ball.ToRectangle());
            if (onfire == true)
            {
                Brush _pixel3 = new SolidBrush(Color.Red);
                e.Graphics.FillRectangle(_pixel3, fire.ToRectangle());
            }
            else
            {
                Brush _pixel3 = new SolidBrush(Color.Navy);
                e.Graphics.FillRectangle(_pixel3, fire.ToRectangle());
            }
            
            MoveBall();
          
           //Thread.Sleep(1);

            _window.Invalidate();
        }
        
        bool z = false;
        private void MoveBall()
        {
            if (z) return;

            switch (_ballDirection)
            {
                case Direction.LeftDown:

                    _ball.X -= 1;
                    _ball.Y += 1;

                    break;

                case Direction.LeftUp:

                    _ball.X -= 1;
                    _ball.Y -= 1;

                    break;

                case Direction.RightDown:

                    _ball.X += 1;
                    _ball.Y += 1;

                    break;

                case Direction.RightUp:

                    _ball.X += 1;
                    _ball.Y -= 1;

                    break;

                case Direction.Left:

                    _ball.X -= 1;

                    break;

                case Direction.Right:

                    _ball.X += 1;

                    break;
            }

            CheckPosition();
        }

        private void CheckPosition()
        {
            if (_ball.X <= 0) 
            {
                onfire = false;
                _ballDirection = Vertical();
            }
            else if (_ball.X >= _window.Width - _ball.Width) 
            {
                onfire = false;
                _ballDirection = Vertical();
            }
            else if (_ball.Y <= 0) 
            {
                //points--;
               
                onfire = false;
                _ballDirection = Horizontal();
            }
            else if (_ball.Y == _window.Height - _ball.Height) 
            {
                onfire = true;
                points--;
                _ballDirection = Horizontal();
            }
            else if ((_ball.Y == _player1.Y - _player1.Height) && (_ball.X >= _player1.X) && (_ball.X <= _player1.X + _player1.Width))
            {
                _ballDirection = Horizontal();
            }
            else if (((_ball.Y == block.Y )||(_ball.Y == block.Y - block.Height)) && (_ball.X >= block.X) && (_ball.X <= block.X + block.Width))
            {
                hit = true;
                blockrelocate();
                _ballDirection = Horizontal();       
            }
        }

  

        private bool IsMovingRight()
        {
            return _ballDirection == Direction.Right || _ballDirection == Direction.RightDown || _ballDirection == Direction.RightUp;
        }

        private Direction Horizontal()
        {
            switch (_ballDirection)
            {
                case Direction.Left:
                    return Direction.Right;

                case Direction.LeftDown:
                    return Direction.LeftUp;

                case Direction.LeftUp:
                    return Direction.LeftDown;

                case Direction.Right:
                    return Direction.Left;

                case Direction.RightDown:
                    return Direction.RightUp;

                case Direction.RightUp:
                    return Direction.RightDown;
            }

            return Direction.Left;
        }

        private Direction Vertical()
        {
            switch (_ballDirection)
            {
                case Direction.Left:
                    return Direction.Right;

                case Direction.LeftDown:
                    return Direction.RightDown;

                case Direction.LeftUp:
                    return Direction.RightUp;

                case Direction.Right:
                    return Direction.Left;

                case Direction.RightDown:
                    return Direction.LeftDown;

                case Direction.RightUp:
                    return Direction.LeftUp;
            }

            return Direction.Left;
        }

        private enum Direction
        {
            LeftDown,
            LeftUp,
            Left,
            RightDown,
            RightUp,
            Right
        }
    }
}
