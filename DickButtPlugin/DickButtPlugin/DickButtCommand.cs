using Rhino;
using Rhino.FileIO;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;
using System;
using System.Collections.Generic;

namespace DickButtPlugin
{
    public class DickButtCommand : Command
    {
        public DickButtCommand()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
        }

        ///<summary>The only instance of this command.</summary>
        public static DickButtCommand Instance { get; private set; }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName => "DickButt";

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            // TODO: start here modifying the behaviour of your command.
            // ---
            RhinoApp.WriteLine("The {0} command will add a dickbutt to your model.", EnglishName);

            Point3d pt0;
            using (GetPoint getPointAction = new GetPoint())
            {
                getPointAction.SetCommandPrompt("Please select the start point");
                if (getPointAction.Get() != GetResult.Point)
                {
                    RhinoApp.WriteLine("No start point was selected.");
                    return getPointAction.CommandResult();
                }
                
                pt0 = getPointAction.Point();
                pt0 = new Rhino.Geometry.Point3d(pt0[0], pt0[1], pt0[2] + 9.85);
            }
            //define the sphere for the head for dickbutt
            Sphere headSphere;
            {
                // center of the circle is the pt0 point picked arlier
                const double radius = 5.0;
                headSphere = new Rhino.Geometry.Sphere(pt0, radius);
            }

            //define the cylinder for the body of dickbutt
            Brep bodyBrep;
            {
                Rhino.Geometry.Point3d center_point = pt0;
                Rhino.Geometry.Point3d height_point = new Rhino.Geometry.Point3d(pt0[0], pt0[1], pt0[2] + 12);
                Rhino.Geometry.Vector3d zaxis = height_point - center_point;
                Rhino.Geometry.Plane plane = new Rhino.Geometry.Plane(center_point, zaxis);
                const double radius = 5;
                Rhino.Geometry.Circle circle = new Rhino.Geometry.Circle(plane, radius);
                Rhino.Geometry.Cylinder cylinder = new Rhino.Geometry.Cylinder(circle, zaxis.Length);
                bodyBrep = cylinder.ToBrep(true, true);

            }

            //define the sphere for the butt for dickbutt
            Sphere buttSphere;
            {
                // center of the circle is the pt0 point picked earlier
                Rhino.Geometry.Point3d height_point = new Rhino.Geometry.Point3d(pt0[0], pt0[1], pt0[2] + 12);
                const double radius = 5.0;
                buttSphere = new Rhino.Geometry.Sphere(height_point, radius);
            }

            //define the cylinder for the body of dickbutt
            Brep buttBrep;
            {
                Rhino.Geometry.Point3d center_point = pt0;
                Rhino.Geometry.Point3d height_point = new Rhino.Geometry.Point3d(pt0[0], pt0[1] + 5, pt0[2]);
                Rhino.Geometry.Vector3d zaxis = height_point - center_point;
                Rhino.Geometry.Plane plane = new Rhino.Geometry.Plane(center_point, zaxis);
                const double radius = 5;
                Rhino.Geometry.Circle circle = new Rhino.Geometry.Circle(plane, radius);
                Rhino.Geometry.Cylinder cylinder = new Rhino.Geometry.Cylinder(circle, zaxis.Length);
                buttBrep = cylinder.ToBrep(true, true);

            }

            //define the sphere for the butt for dickbutt
            Sphere buttendSphere;
            {
                // center of the circle is the pt0 point picked earlier
                Rhino.Geometry.Point3d height_point = new Rhino.Geometry.Point3d(pt0[0], pt0[1] + 5, pt0[2]);
                const double radius = 5.0;
                buttendSphere = new Rhino.Geometry.Sphere(height_point, radius);
            }

            //define the sphere for the butt for dickbutt
            Sphere leftLegSphere;
            {
                // center of the circle is the pt0 point picked earlier
                Rhino.Geometry.Point3d height_point = new Rhino.Geometry.Point3d(pt0[0] - 2.36, pt0[1], pt0[2] - 9);
                const double radius = 0.85;
                leftLegSphere = new Rhino.Geometry.Sphere(height_point, radius);
            }
            //define the cylinder for the body of dickbutt
            Brep leftLeg;
            {
                Rhino.Geometry.Point3d height_point = new Rhino.Geometry.Point3d(pt0[0] - 2.36, pt0[1], pt0[2] - 9);
                Rhino.Geometry.Vector3d zaxis = new Rhino.Geometry.Vector3d(0.0, 0.0, 5.5);
                Rhino.Geometry.Plane plane = new Rhino.Geometry.Plane(height_point, zaxis);
                const double radius = 0.85;
                Rhino.Geometry.Circle circle = new Rhino.Geometry.Circle(plane, radius);
                Rhino.Geometry.Cylinder cylinder = new Rhino.Geometry.Cylinder(circle, zaxis.Length);
                leftLeg = cylinder.ToBrep(true, true);

            }

            //define the sphere for the butt for dickbutt
            Sphere rightLegSphere;
            {
                // center of the circle is the pt0 point picked earlier
                Rhino.Geometry.Point3d height_point = new Rhino.Geometry.Point3d(pt0[0] + 2.36, pt0[1], pt0[2] - 9);
                const double radius = 0.85;
                rightLegSphere = new Rhino.Geometry.Sphere(height_point, radius);
            }

            //define the cylinder for the body of dickbutt
            Brep rightLeg;
            {
                Rhino.Geometry.Point3d height_point = new Rhino.Geometry.Point3d(pt0[0] + 2.36, pt0[1], pt0[2] - 9);
                Rhino.Geometry.Vector3d zaxis = new Rhino.Geometry.Vector3d(0.0, 0.0, 5.5);
                Rhino.Geometry.Plane plane = new Rhino.Geometry.Plane(height_point, zaxis);
                const double radius = 0.85;
                Rhino.Geometry.Circle circle = new Rhino.Geometry.Circle(plane, radius);
                Rhino.Geometry.Cylinder cylinder = new Rhino.Geometry.Cylinder(circle, zaxis.Length);
                rightLeg = cylinder.ToBrep(true, true);

            }

            //define the sphere for the eyes of dickbutt
            Sphere rightMouthSphere;
            {
                // center of the circle is the pt0 point picked earlier
                Rhino.Geometry.Point3d height_point = new Rhino.Geometry.Point3d(pt0[0] + 2.09, pt0[1] - 4.63, pt0[2] + 9.25);
                const double radius = 0.85;
                rightMouthSphere = new Rhino.Geometry.Sphere(height_point, radius);
            }

            //define the sphere for the eyes of dickbutt
            Sphere leftMouthSphere;
            {
                // center of the circle is the pt0 point picked earlier
                Rhino.Geometry.Point3d height_point = new Rhino.Geometry.Point3d(pt0[0] - 2.09, pt0[1] - 4.63, pt0[2] + 9.25);
                const double radius = 0.85;
                leftMouthSphere = new Rhino.Geometry.Sphere(height_point, radius);
            }

            //define the cylinder for the body of dickbutt
            Brep mouthBrep;
            {
                Rhino.Geometry.Point3d center_point = new Rhino.Geometry.Point3d(pt0[0] - 2.09, pt0[1] - 4.63, pt0[2] + 9.25);
                Rhino.Geometry.Point3d height_point = new Rhino.Geometry.Point3d(pt0[0] + 2.09, pt0[1] - 4.63, pt0[2] + 9.25);
                Rhino.Geometry.Vector3d zaxis = height_point - center_point;
                Rhino.Geometry.Plane plane = new Rhino.Geometry.Plane(center_point, zaxis);
                const double radius = .85;
                Rhino.Geometry.Circle circle = new Rhino.Geometry.Circle(plane, radius);
                Rhino.Geometry.Cylinder cylinder = new Rhino.Geometry.Cylinder(circle, zaxis.Length);
                mouthBrep = cylinder.ToBrep(true, true);

            }

            //define the sphere for the dick balls of dickbutt
            Sphere leftdickballSphere;
            {
                // center of the circle is the pt0 point picked earlier
                Rhino.Geometry.Point3d height_point = new Rhino.Geometry.Point3d(pt0[0] - 1, pt0[1] + 8.14, pt0[2] +3.86);
                const double radius = 1.5;
                leftdickballSphere = new Rhino.Geometry.Sphere(height_point, radius);
            }

            //define the sphere for the dick balls of dickbutt
            Sphere rightdickballSphere;
            {
                // center of the circle is the pt0 point picked earlier
                Rhino.Geometry.Point3d height_point = new Rhino.Geometry.Point3d(pt0[0] + 1, pt0[1] + 8.14, pt0[2] + 3.86);
                const double radius = 1.5;
                rightdickballSphere = new Rhino.Geometry.Sphere(height_point, radius);
            }

            //define the cylinder for the body of dickbutt
            Brep dickBrep;
            {
                Rhino.Geometry.Point3d center_point = new Rhino.Geometry.Point3d(pt0[0], pt0[1] + 8.14, pt0[2] + 3.86);
                Rhino.Geometry.Vector3d zaxis = new Rhino.Geometry.Vector3d(0.0, 0.0, 5.5);
                Rhino.Geometry.Plane plane = new Rhino.Geometry.Plane(center_point, zaxis);
                const double radius = 1;
                Rhino.Geometry.Circle circle = new Rhino.Geometry.Circle(plane, radius);
                Rhino.Geometry.Cylinder cylinder = new Rhino.Geometry.Cylinder(circle, zaxis.Length);
                dickBrep = cylinder.ToBrep(true, true);

            }

            //define the sphere for the dick balls of dickbutt
            Sphere dickTipSphere;
            {
                // center of the circle is the pt0 point picked earlier
                Rhino.Geometry.Point3d height_point = new Rhino.Geometry.Point3d(pt0[0], pt0[1] + 8.14, pt0[2] + 9.36);
                const double radius = 1;
                dickTipSphere = new Rhino.Geometry.Sphere(height_point, radius);
            }

            //define the sphere for the eyes of dickbutt
            Sphere leftEyeSphere;
            {
                // center of the circle is the pt0 point picked earlier
                Rhino.Geometry.Point3d height_point = new Rhino.Geometry.Point3d(pt0[0] + 2.42, pt0[1] - 4.03, pt0[2] + 12.78);
                const double radius = 1.20;
                leftEyeSphere = new Rhino.Geometry.Sphere(height_point, radius);
            }

            //define the sphere for the eyes of dickbutt
            Sphere rightEyeSphere;
            {
                // center of the circle is the pt0 point picked earlier
                Rhino.Geometry.Point3d height_point = new Rhino.Geometry.Point3d(pt0[0] - 2.42, pt0[1] - 4.03, pt0[2] + 12.78);
                const double radius = 1.20;
                rightEyeSphere = new Rhino.Geometry.Sphere(height_point, radius);
            }

            //define the sphere for the eyes of dickbutt
            Sphere noseSphere;
            {
                // center of the circle is the pt0 point picked earlier
                Rhino.Geometry.Point3d height_point = new Rhino.Geometry.Point3d(pt0[0], pt0[1] - 8.03, pt0[2] + 11.17);
                const double radius = 0.85;
                noseSphere = new Rhino.Geometry.Sphere(height_point, radius);
            }

            //define the cylinder for the body of dickbutt
            Brep noseBrep;
            {
                Rhino.Geometry.Point3d center_point = new Rhino.Geometry.Point3d(pt0[0], pt0[1] - 4.03, pt0[2] + 11.17);
                Rhino.Geometry.Vector3d zaxis = new Rhino.Geometry.Vector3d(0.0, -4.0, 0.0);
                Rhino.Geometry.Plane plane = new Rhino.Geometry.Plane(center_point, zaxis);
                const double radius = 0.85;
                Rhino.Geometry.Circle circle = new Rhino.Geometry.Circle(plane, radius);
                Rhino.Geometry.Cylinder cylinder = new Rhino.Geometry.Cylinder(circle, zaxis.Length);
                noseBrep = cylinder.ToBrep(true, true);

            }


            doc.Objects.AddBrep(bodyBrep);
            doc.Objects.AddBrep(buttBrep);
            doc.Objects.AddBrep(mouthBrep);
            doc.Objects.AddBrep(leftLeg);
            doc.Objects.AddBrep(rightLeg);
            doc.Objects.AddBrep(dickBrep);
            doc.Objects.AddBrep(noseBrep);

            doc.Objects.AddSphere(leftLegSphere);
            doc.Objects.AddSphere(buttendSphere);
            doc.Objects.AddSphere(rightLegSphere);
            doc.Objects.AddSphere(leftdickballSphere);
            doc.Objects.AddSphere(rightdickballSphere);
            doc.Objects.AddSphere(dickTipSphere);


            doc.Objects.AddSphere(leftEyeSphere);
            doc.Objects.AddSphere(rightEyeSphere);
            doc.Objects.AddSphere(leftMouthSphere);
            doc.Objects.AddSphere(rightMouthSphere);
            doc.Objects.AddSphere(noseSphere);




            doc.Objects.AddSphere(headSphere);
            doc.Objects.AddSphere(buttSphere);

            doc.Views.Redraw();
            RhinoApp.WriteLine("The {0} command added one dickbutt to the document.", EnglishName);

            // ---
            return Result.Success;
        }
    }
}
