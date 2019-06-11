using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    class Director
    {
        builder builder;
        public Director(builder builder)
        {
            this.builder = builder;
        }
        public void Construct(bool first, bool sec, bool third )
        {
            if(first==true)
            {
                builder.BuildCircle();
            }
            if (sec == true)
            {
                builder.BuildQuad();
            }
            if (third == true)
            {
                builder.BuildRect();
            }
        }
    }

    class Product
    {
        public List<object> prod = new List<object>();
        public void add(object product)
        {
            prod.Add(product);
        }
    }

    abstract class builder
    {
        public abstract void BuildCircle();
        public abstract void BuildQuad();
        public abstract void BuildRect();
        public abstract Product GetResult();
    }

    class ConcreteBuilder : builder
    {
        Product p = new Product();
        public override void BuildCircle()
        {
            CircleFactory cf = new CircleFactory();
            drawCircle crc = (drawCircle)cf.makeShape();
            p.add(crc.e);
        }

        public override void BuildQuad()
        {
            QuadFactory qf = new QuadFactory();
            drawQuad qd = (drawQuad)qf.makeShape();
            p.add(qd.r);
        }

        public override void BuildRect()
        {
            RectFactory rf = new RectFactory();
            drawRect rct = (drawRect)rf.makeShape();
            p.add(rct.r);
        }

        public override Product GetResult()
        {
            return p;
        }
    }
}
