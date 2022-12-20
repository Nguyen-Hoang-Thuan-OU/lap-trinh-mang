using System;
using System.Threading;
class ThreadPoolSample
{
    public static void Main()
    {
        // tạo đối tượng ThreadPoolSample tps
        ThreadPoolSample tps = new ThreadPoolSample();
    }
    public ThreadPoolSample()
    {
        int i;
        // đăng ký một ủy quyền cho việc sử dụng các thread trong threadpool
        // sử dụng hàm WaitCallBack với ủy thác là biến couter
        ThreadPool.QueueUserWorkItem(new WaitCallback(Counter));
        ThreadPool.QueueUserWorkItem(new WaitCallback(Counter2));
        //tạo vòng lập 10 lần
        for (i = 0; i < 10; i++)
        {
            // in ra màn hình giá trị main: +  thứ i
            Console.WriteLine("main: {0}", i);
            // hàm sleep dùng để làm cho luồng hiện tại ngủ theo thời gian cài đặt
            Thread.Sleep(1000);
        }
    }
    void Counter(object state)
    {
        int i;
        // thực hiện vòng lập 10 lần 
        for (i = 0; i < 10; i++)
        {
            //in ra giá trị thread + vị trí thứ i
            Console.WriteLine(" thread: {0}", i);
            // với thời gian ngủ đc chỉ định
            Thread.Sleep(2000);
        }
    }
    void Counter2(object state)
    {
        int i;
        // thực hiện vòng lập 10 lần 
        for (i = 0; i < 10; i++)
        {
            //in ra giá trị thread + vị trí thứ i
            Console.WriteLine(" thread2: {0}", i);
            // với thời gian ngủ đc chỉ định
            Thread.Sleep(3000);
        }
    }
}
