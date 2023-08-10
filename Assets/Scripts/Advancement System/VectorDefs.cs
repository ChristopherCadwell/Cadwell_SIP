using System;
using UnityEngine;

namespace NVectors
{
    public struct Vector4
    {
        public float a;
        public float b;
        public float c;
        public float d;

        public Vector4(float a, float b, float c, float d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }
        public static Vector4 Lerp(Vector4 start, Vector4 end, float t)
        {
            t = Mathf.Clamp01(t);
            return new Vector4(Mathf.Lerp(start.a, end.a, t), Mathf.Lerp(start.b, end.b, t), Mathf.Lerp(start.c, end.c, t), Mathf.Lerp(start.d, end.d, t));
        }


        // Vector addition
        public static Vector4 operator +(Vector4 v1, Vector4 v2)
        {
            return new Vector4(v1.a + v2.a, v1.b + v2.b, v1.c + v2.c, v1.d + v2.d);
        }

        // Scalar multiplication
        public static Vector4 operator *(Vector4 v, float scalar)
        {
            return new Vector4(v.a * scalar, v.b * scalar, v.c * scalar, v.d * scalar);
        }

        // Magnitude
        public float Magnitude()
        {
            return Mathf.Sqrt(a * a + b * b + c * c + d * d);
        }

        // Normalization
        public Vector4 Normalize()
        {
            float magnitude = Magnitude();
            return new Vector4(a / magnitude, b / magnitude, c / magnitude, d / magnitude);
        }

        // Dot Product
        public static float DotProduct(Vector4 v1, Vector4 v2)
        {
            return v1.a * v2.a + v1.b * v2.b + v1.c * v2.c + v1.d * v2.d;
        }

        // Equality and Inequality Operators
        public static bool operator ==(Vector4 v1, Vector4 v2)
        {
            return v1.a == v2.a && v1.b == v2.b && v1.c == v2.c && v1.d == v2.d;
        }

        public static bool operator !=(Vector4 v1, Vector4 v2)
        {
            return !(v1 == v2);
        }

        // Indexer
        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return a;
                    case 1: return b;
                    case 2: return c;
                    case 3: return d;
                    default: throw new IndexOutOfRangeException("Index out of range for Vector4");
                }
            }
            set
            {
                switch (index)
                {
                    case 0: a = value; break;
                    case 1: b = value; break;
                    case 2: c = value; break;
                    case 3: d = value; break;
                    default: throw new IndexOutOfRangeException("Index out of range for Vector4");
                }
            }
        }

        // Overrides
        public override bool Equals(object obj)
        {
            if (obj is Vector4 v)
            {
                return this == v;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return a.GetHashCode() ^ b.GetHashCode() ^ c.GetHashCode() ^ d.GetHashCode();
        }
    }
    public struct Vector5
    {
        public float a;
        public float b;
        public float c;
        public float d;
        public float e;

        public Vector5(float a, float b, float c, float d, float e)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.e = e;
        }
        public static Vector5 Lerp(Vector5 start, Vector5 end, float t)
        {
            t = Mathf.Clamp01(t);
            return new Vector5(Mathf.Lerp(start.a, end.a, t), Mathf.Lerp(start.b, end.b, t), Mathf.Lerp(start.c, end.c, t), Mathf.Lerp(start.d, end.d, t), Mathf.Lerp(start.e, end.e, t));
        }


        // Vector addition
        public static Vector5 operator +(Vector5 v1, Vector5 v2)
        {
            return new Vector5(v1.a + v2.a, v1.b + v2.b, v1.c + v2.c, v1.d + v2.d, v1.e + v2.e);
        }

        // Scalar multiplication
        public static Vector5 operator *(Vector5 v, float scalar)
        {
            return new Vector5(v.a * scalar, v.b * scalar, v.c * scalar, v.d * scalar, v.e * scalar);
        }

        // Magnitude
        public float Magnitude()
        {
            return Mathf.Sqrt(a * a + b * b + c * c + d * d + e * e);
        }

        // Normalization
        public Vector5 Normalize()
        {
            float magnitude = Magnitude();
            return new Vector5(a / magnitude, b / magnitude, c / magnitude, d / magnitude, e / magnitude);
        }

        // Dot Product
        public static float DotProduct(Vector5 v1, Vector5 v2)
        {
            return v1.a * v2.a + v1.b * v2.b + v1.c * v2.c + v1.d * v2.d + v1.e * v2.e;
        }

        // Equality and Inequality Operators
        public static bool operator ==(Vector5 v1, Vector5 v2)
        {
            return v1.a == v2.a && v1.b == v2.b && v1.c == v2.c && v1.d == v2.d && v1.e == v2.e;
        }

        public static bool operator !=(Vector5 v1, Vector5 v2)
        {
            return !(v1 == v2);
        }

        // Indexer
        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return a;
                    case 1: return b;
                    case 2: return c;
                    case 3: return d;
                    case 4: return e;
                    default: throw new IndexOutOfRangeException("Index out of range for Vector5");
                }
            }
            set
            {
                switch (index)
                {
                    case 0: a = value; break;
                    case 1: b = value; break;
                    case 2: c = value; break;
                    case 3: d = value; break;
                    case 4: e = value; break;
                    default: throw new IndexOutOfRangeException("Index out of range for Vector5");
                }
            }
        }
        // Overrides
        public override bool Equals(object obj)
        {
            if (obj is Vector5 v)
            {
                return this == v;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return a.GetHashCode() ^ b.GetHashCode() ^ c.GetHashCode() ^ d.GetHashCode() ^ e.GetHashCode();
        }
    }
    public struct Vector6
    {
        public float a;
        public float b;
        public float c;
        public float d;
        public float e;
        public float f;

        public Vector6(float a, float b, float c, float d, float e, float f)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.e = e;
            this.f = f;
        }
        public float Max()
        {
            return Mathf.Max(a, b, c, d, e, f);
        }
        public static Vector6 Lerp(Vector6 start, Vector6 end, float t)
        {
            t = Mathf.Clamp01(t);
            return new Vector6(Mathf.Lerp(start.a, end.a, t), Mathf.Lerp(start.b, end.b, t), Mathf.Lerp(start.c, end.c, t), Mathf.Lerp(start.d, end.d, t), Mathf.Lerp(start.e, end.e, t), Mathf.Lerp(start.f, end.f, t));
        }


        // Vector addition
        public static Vector6 operator +(Vector6 v1, Vector6 v2)
        {
            return new Vector6(v1.a + v2.a, v1.b + v2.b, v1.c + v2.c, v1.d + v2.d, v1.e + v2.e, v1.f + v2.f);
        }

        //Subtraction
        public static Vector6 operator -(Vector6 a, Vector6 b)
        {
            return new Vector6(a.a - b.a, a.b - b.b, a.c - b.c, a.d - b.d, a.e - b.e, a.f - b.f);
        }

        // Scalar multiplication
        public static Vector6 operator *(Vector6 v, float scalar)
        {
            return new Vector6(v.a * scalar, v.b * scalar, v.c * scalar, v.d * scalar, v.e * scalar, v.f * scalar);
        }

        // Magnitude
        public float Magnitude()
        {
            return Mathf.Sqrt(a * a + b * b + c * c + d * d + e * e + f * f);
        }

        // Normalization
        public Vector6 Normalize()
        {
            float magnitude = Magnitude();
            return new Vector6(a / magnitude, b / magnitude, c / magnitude, d / magnitude, e / magnitude, f / magnitude);
        }

        // Dot Product
        public static float DotProduct(Vector6 v1, Vector6 v2)
        {
            return v1.a * v2.a + v1.b * v2.b + v1.c * v2.c + v1.d * v2.d + v1.e * v2.e + v1.f * v2.f;
        }

        // Equality and Inequality Operators
        public static bool operator ==(Vector6 v1, Vector6 v2)
        {
            return v1.a == v2.a && v1.b == v2.b && v1.c == v2.c && v1.d == v2.d && v1.e == v2.e && v1.f == v2.f;
        }

        public static bool operator !=(Vector6 v1, Vector6 v2)
        {
            return !(v1 == v2);
        }

        // Indexer
        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return a;
                    case 1: return b;
                    case 2: return c;
                    case 3: return d;
                    case 4: return e;
                    case 5: return f;
                    default: throw new IndexOutOfRangeException("Index out of range for Vector6");
                }
            }
            set
            {
                switch (index)
                {
                    case 0: a = value; break;
                    case 1: b = value; break;
                    case 2: c = value; break;
                    case 3: d = value; break;
                    case 4: e = value; break;
                    case 5: f = value; break;
                    default: throw new IndexOutOfRangeException("Index out of range for Vector6");
                }
            }
        }
        // Overrides
        public override bool Equals(object obj)
        {
            if (obj is Vector6 v)
            {
                return this == v;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return a.GetHashCode() ^ b.GetHashCode() ^ c.GetHashCode() ^ d.GetHashCode() ^ e.GetHashCode() ^ f.GetHashCode();
        }
    }
    public struct Vector7
    {
        public float a;
        public float b;
        public float c;
        public float d;
        public float e;
        public float f;
        public float g;

        public Vector7(float a, float b, float c, float d, float e, float f, float g)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.e = e;
            this.f = f;
            this.g = g;
        }
        public static Vector7 Lerp(Vector7 start, Vector7 end, float t)
        {
            t = Mathf.Clamp01(t);
            return new Vector7(Mathf.Lerp(start.a, end.a, t), Mathf.Lerp(start.b, end.b, t), Mathf.Lerp(start.c, end.c, t), Mathf.Lerp(start.d, end.d, t), Mathf.Lerp(start.e, end.e, t), Mathf.Lerp(start.f, end.f, t), Mathf.Lerp(start.g, end.g, t));
        }


        // Vector addition
        public static Vector7 operator +(Vector7 v1, Vector7 v2)
        {
            return new Vector7(v1.a + v2.a, v1.b + v2.b, v1.c + v2.c, v1.d + v2.d, v1.e + v2.e, v1.f + v2.f, v1.g + v2.g);
        }

        // Scalar multiplication
        public static Vector7 operator *(Vector7 v, float scalar)
        {
            return new Vector7(v.a * scalar, v.b * scalar, v.c * scalar, v.d * scalar, v.e * scalar, v.f * scalar, v.g * scalar);
        }

        // Magnitude
        public float Magnitude()
        {
            return Mathf.Sqrt(a * a + b * b + c * c + d * d + e * e + f * f + g * g);
        }

        // Normalization
        public Vector7 Normalize()
        {
            float magnitude = Magnitude();
            return new Vector7(a / magnitude, b / magnitude, c / magnitude, d / magnitude, e / magnitude, f / magnitude, g / magnitude);
        }

        // Dot Product
        public static float DotProduct(Vector7 v1, Vector7 v2)
        {
            return v1.a * v2.a + v1.b * v2.b + v1.c * v2.c + v1.d * v2.d + v1.e * v2.e + v1.f * v2.f + v1.g * v2.g;
        }

        // Equality and Inequality Operators
        public static bool operator ==(Vector7 v1, Vector7 v2)
        {
            return v1.a == v2.a && v1.b == v2.b && v1.c == v2.c && v1.d == v2.d && v1.e == v2.e && v1.f == v2.f && v1.g == v2.g;
        }

        public static bool operator !=(Vector7 v1, Vector7 v2)
        {
            return !(v1 == v2);
        }

        // Indexer
        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return a;
                    case 1: return b;
                    case 2: return c;
                    case 3: return d;
                    case 4: return e;
                    case 5: return f;
                    case 6: return g;
                    default: throw new IndexOutOfRangeException("Index out of range for Vector7");
                }
            }
            set
            {
                switch (index)
                {
                    case 0: a = value; break;
                    case 1: b = value; break;
                    case 2: c = value; break;
                    case 3: d = value; break;
                    case 4: e = value; break;
                    case 5: f = value; break;
                    case 6: g = value; break;
                    default: throw new IndexOutOfRangeException("Index out of range for Vector7");
                }
            }
        }
        // Overrides
        public override bool Equals(object obj)
        {
            if (obj is Vector7 v)
            {
                return this == v;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return a.GetHashCode() ^ b.GetHashCode() ^ c.GetHashCode() ^ d.GetHashCode() ^ e.GetHashCode() ^ f.GetHashCode() ^ g.GetHashCode();
        }
    }
    public struct Vector8
    {
        public float a;
        public float b;
        public float c;
        public float d;
        public float e;
        public float f;
        public float g;
        public float h;

        public Vector8(float a, float b, float c, float d, float e, float f, float g, float h)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.e = e;
            this.f = f;
            this.g = g;
            this.h = h;
        }
        public static Vector8 Lerp(Vector8 start, Vector8 end, float t)
        {
            t = Mathf.Clamp01(t);
            return new Vector8(Mathf.Lerp(start.a, end.a, t), Mathf.Lerp(start.b, end.b, t), Mathf.Lerp(start.c, end.c, t), Mathf.Lerp(start.d, end.d, t), Mathf.Lerp(start.e, end.e, t), Mathf.Lerp(start.f, end.f, t), Mathf.Lerp(start.g, end.g, t), Mathf.Lerp(start.h, end.h, t));
        }


        // Vector addition
        public static Vector8 operator +(Vector8 v1, Vector8 v2)
        {
            return new Vector8(v1.a + v2.a, v1.b + v2.b, v1.c + v2.c, v1.d + v2.d, v1.e + v2.e, v1.f + v2.f, v1.g + v2.g, v1.h + v2.h);
        }

        // Scalar multiplication
        public static Vector8 operator *(Vector8 v, float scalar)
        {
            return new Vector8(v.a * scalar, v.b * scalar, v.c * scalar, v.d * scalar, v.e * scalar, v.f * scalar, v.g * scalar, v.h * scalar);
        }

        // Magnitude
        public float Magnitude()
        {
            return Mathf.Sqrt(a * a + b * b + c * c + d * d + e * e + f * f + g * g + h * h);
        }

        // Normalization
        public Vector8 Normalize()
        {
            float magnitude = Magnitude();
            return new Vector8(a / magnitude, b / magnitude, c / magnitude, d / magnitude, e / magnitude, f / magnitude, g / magnitude, h / magnitude);
        }

        // Dot Product
        public static float DotProduct(Vector8 v1, Vector8 v2)
        {
            return v1.a * v2.a + v1.b * v2.b + v1.c * v2.c + v1.d * v2.d + v1.e * v2.e + v1.f * v2.f + v1.g * v2.g + v1.h * v2.h;
        }

        // Equality and Inequality Operators
        public static bool operator ==(Vector8 v1, Vector8 v2)
        {
            return v1.a == v2.a && v1.b == v2.b && v1.c == v2.c && v1.d == v2.d && v1.e == v2.e && v1.f == v2.f && v1.g == v2.g && v1.h == v2.h;
        }

        public static bool operator !=(Vector8 v1, Vector8 v2)
        {
            return !(v1 == v2);
        }

        // Indexer
        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return a;
                    case 1: return b;
                    case 2: return c;
                    case 3: return d;
                    case 4: return e;
                    case 5: return f;
                    case 6: return g;
                    case 7: return h;
                    default: throw new IndexOutOfRangeException("Index out of range for Vector8");
                }
            }
            set
            {
                switch (index)
                {
                    case 0: a = value; break;
                    case 1: b = value; break;
                    case 2: c = value; break;
                    case 3: d = value; break;
                    case 4: e = value; break;
                    case 5: f = value; break;
                    case 6: g = value; break;
                    case 7: h = value; break;
                    default: throw new IndexOutOfRangeException("Index out of range for Vector8");
                }
            }
        }
        // Overrides
        public override bool Equals(object obj)
        {
            if (obj is Vector8 v)
            {
                return this == v;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return a.GetHashCode() ^ b.GetHashCode() ^ c.GetHashCode() ^ d.GetHashCode() ^ e.GetHashCode() ^ f.GetHashCode() ^ g.GetHashCode() ^ h.GetHashCode();
        }
    }
    public struct Vector9
    {
        public float a;
        public float b;
        public float c;
        public float d;
        public float e;
        public float f;
        public float g;
        public float h;
        public float i;

        public Vector9(float a, float b, float c, float d, float e, float f, float g, float h, float i)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.e = e;
            this.f = f;
            this.g = g;
            this.h = h;
            this.i = i;
        }
        public static Vector9 Lerp(Vector9 start, Vector9 end, float t)
        {
            t = Mathf.Clamp01(t);
            return new Vector9(Mathf.Lerp(start.a, end.a, t), Mathf.Lerp(start.b, end.b, t), Mathf.Lerp(start.c, end.c, t), Mathf.Lerp(start.d, end.d, t), Mathf.Lerp(start.e, end.e, t), Mathf.Lerp(start.f, end.f, t), Mathf.Lerp(start.g, end.g, t), Mathf.Lerp(start.h, end.h, t), Mathf.Lerp(start.i, end.i, t));
        }


        // Vector addition
        public static Vector9 operator +(Vector9 v1, Vector9 v2)
        {
            return new Vector9(v1.a + v2.a, v1.b + v2.b, v1.c + v2.c, v1.d + v2.d, v1.e + v2.e, v1.f + v2.f, v1.g + v2.g, v1.h + v2.h, v1.i + v2.i);
        }

        // Scalar multiplication
        public static Vector9 operator *(Vector9 v, float scalar)
        {
            return new Vector9(v.a * scalar, v.b * scalar, v.c * scalar, v.d * scalar, v.e * scalar, v.f * scalar, v.g * scalar, v.h * scalar, v.i * scalar);
        }

        // Magnitude
        public float Magnitude()
        {
            return Mathf.Sqrt(a * a + b * b + c * c + d * d + e * e + f * f + g * g + h * h + i * i);
        }

        // Normalization
        public Vector9 Normalize()
        {
            float magnitude = Magnitude();
            return new Vector9(a / magnitude, b / magnitude, c / magnitude, d / magnitude, e / magnitude, f / magnitude, g / magnitude, h / magnitude, i / magnitude);
        }

        // Dot Product
        public static float DotProduct(Vector9 v1, Vector9 v2)
        {
            return v1.a * v2.a + v1.b * v2.b + v1.c * v2.c + v1.d * v2.d + v1.e * v2.e + v1.f * v2.f + v1.g * v2.g + v1.h * v2.h + v1.i * v2.i;
        }

        // Equality and Inequality Operators
        public static bool operator ==(Vector9 v1, Vector9 v2)
        {
            return v1.a == v2.a && v1.b == v2.b && v1.c == v2.c && v1.d == v2.d && v1.e == v2.e && v1.f == v2.f && v1.g == v2.g && v1.h == v2.h && v1.i == v2.i;
        }

        public static bool operator !=(Vector9 v1, Vector9 v2)
        {
            return !(v1 == v2);
        }

        // Indexer
        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return a;
                    case 1: return b;
                    case 2: return c;
                    case 3: return d;
                    case 4: return e;
                    case 5: return f;
                    case 6: return g;
                    case 7: return h;
                    case 8: return i;
                    default: throw new IndexOutOfRangeException("Index out of range for Vector9");
                }
            }
            set
            {
                switch (index)
                {
                    case 0: a = value; break;
                    case 1: b = value; break;
                    case 2: c = value; break;
                    case 3: d = value; break;
                    case 4: e = value; break;
                    case 5: f = value; break;
                    case 6: g = value; break;
                    case 7: h = value; break;
                    case 8: i = value; break;
                    default: throw new IndexOutOfRangeException("Index out of range for Vector9");
                }
            }
        }
        // Overrides
        public override bool Equals(object obj)
        {
            if (obj is Vector9 v)
            {
                return this == v;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return a.GetHashCode() ^ b.GetHashCode() ^ c.GetHashCode() ^ d.GetHashCode() ^ e.GetHashCode() ^ f.GetHashCode() ^ g.GetHashCode() ^ h.GetHashCode() ^ i.GetHashCode();
        }
    }
    public struct Vector10
    {
        public float a;
        public float b;
        public float c;
        public float d;
        public float e;
        public float f;
        public float g;
        public float h;
        public float i;
        public float j;

        public Vector10(float a, float b, float c, float d, float e, float f, float g, float h, float i, float j)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.e = e;
            this.f = f;
            this.g = g;
            this.h = h;
            this.i = i;
            this.j = j;
        }
        public static Vector10 Lerp(Vector10 start, Vector10 end, float t)
        {
            t = Mathf.Clamp01(t);
            return new Vector10(Mathf.Lerp(start.a, end.a, t), Mathf.Lerp(start.b, end.b, t), Mathf.Lerp(start.c, end.c, t), Mathf.Lerp(start.d, end.d, t), Mathf.Lerp(start.e, end.e, t), Mathf.Lerp(start.f, end.f, t), Mathf.Lerp(start.g, end.g, t), Mathf.Lerp(start.h, end.h, t), Mathf.Lerp(start.i, end.i, t), Mathf.Lerp(start.j, end.j, t));
        }


        // Vector addition
        public static Vector10 operator +(Vector10 v1, Vector10 v2)
        {
            return new Vector10(v1.a + v2.a, v1.b + v2.b, v1.c + v2.c, v1.d + v2.d, v1.e + v2.e, v1.f + v2.f, v1.g + v2.g, v1.h + v2.h, v1.i + v2.i, v1.j + v2.j);
        }

        // Scalar multiplication
        public static Vector10 operator *(Vector10 v, float scalar)
        {
            return new Vector10(v.a * scalar, v.b * scalar, v.c * scalar, v.d * scalar, v.e * scalar, v.f * scalar, v.g * scalar, v.h * scalar, v.i * scalar, v.j * scalar);
        }

        // Magnitude
        public float Magnitude()
        {
            return Mathf.Sqrt(a * a + b * b + c * c + d * d + e * e + f * f + g * g + h * h + i * i + j * j);
        }

        // Normalization
        public Vector10 Normalize()
        {
            float magnitude = Magnitude();
            return new Vector10(a / magnitude, b / magnitude, c / magnitude, d / magnitude, e / magnitude, f / magnitude, g / magnitude, h / magnitude, i / magnitude, j / magnitude);
        }

        // Dot Product
        public static float DotProduct(Vector10 v1, Vector10 v2)
        {
            return v1.a * v2.a + v1.b * v2.b + v1.c * v2.c + v1.d * v2.d + v1.e * v2.e + v1.f * v2.f + v1.g * v2.g + v1.h * v2.h + v1.i * v2.i + v1.j * v2.j;
        }

        // Equality and Inequality Operators
        public static bool operator ==(Vector10 v1, Vector10 v2)
        {
            return v1.a == v2.a && v1.b == v2.b && v1.c == v2.c && v1.d == v2.d && v1.e == v2.e && v1.f == v2.f && v1.g == v2.g && v1.h == v2.h && v1.i == v2.i && v1.j == v2.j;
        }

        public static bool operator !=(Vector10 v1, Vector10 v2)
        {
            return !(v1 == v2);
        }

        // Indexer
        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return a;
                    case 1: return b;
                    case 2: return c;
                    case 3: return d;
                    case 4: return e;
                    case 5: return f;
                    case 6: return g;
                    case 7: return h;
                    case 8: return i;
                    case 9: return j;
                    default: throw new IndexOutOfRangeException("Index out of range for Vector10");
                }
            }
            set
            {
                switch (index)
                {
                    case 0: a = value; break;
                    case 1: b = value; break;
                    case 2: c = value; break;
                    case 3: d = value; break;
                    case 4: e = value; break;
                    case 5: f = value; break;
                    case 6: g = value; break;
                    case 7: h = value; break;
                    case 8: i = value; break;
                    case 9: j = value; break;
                    default: throw new IndexOutOfRangeException("Index out of range for Vector10");
                }
            }
        }

        // Overrides
        public override bool Equals(object obj)
        {
            if (obj is Vector10 v)
            {
                return this == v;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return a.GetHashCode() ^ b.GetHashCode() ^ c.GetHashCode() ^ d.GetHashCode() ^ e.GetHashCode() ^ f.GetHashCode() ^ g.GetHashCode() ^ h.GetHashCode() ^ i.GetHashCode() ^ j.GetHashCode();
        }
    }
}
