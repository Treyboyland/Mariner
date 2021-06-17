using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestClass : MonoBehaviour
{
    public enum TestEnum
    {
        ONE = 0,

        THREE = 2,
        FOUR = 3
    }

    public TestEnum blah;

    public int Prop { get; set; } = 123;

    public readonly int Prop2 = 145;

    public const int PROP = 123;

    struct TestStruct
    {
        public int A;
        public int B;

        public override string ToString()
        {
            return A + " " + B;
        }
    }

    class TestBlah
    {
        public int A;
        public int B;

        public override string ToString()
        {
            return A + " " + B;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        TestBlah test = new TestBlah() { A = 1, B = 1 };
        Debug.Log("Before: " + test);
        TestMethod(test);
        Debug.Log("After: " + test);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TestMethod(TestStruct a)
    {
        a.B = 33;
        Debug.Log("Method Change var: " + a);
        a = new TestStruct() { A = 5, B = 5 };
        Debug.Log("Mehtod: " + a);
    }

    void TestMethod(TestBlah a)
    {
        a.B = 33;
        Debug.Log("Method Change var: " + a);
        a = new TestBlah() { A = 5, B = 5 };
        Debug.Log("Mehtod: " + a);
    }
}
