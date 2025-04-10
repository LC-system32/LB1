public class Main {
    public static void main(String[] args) {
        StartThread[] threads = new StartThread[3];

        for (int i = 0; i < threads.length; i++) {
            threads[i] = new StartThread(i + 1, 1);
            threads[i].start();
        }

        new StopThread(threads, new int[]{100, 200, 700}).start();
    }
}
