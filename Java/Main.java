public class Main {
    public static void main(String[] args) {
        StartThread[] threads = new StartThread[5];
        int[] millis = {8000, 5000,9000,15000,10000};

        for (int i = 0; i < threads.length; i++) {
            threads[i] = new StartThread(i + 1, 1, millis[i]);
            threads[i].start();
        }

        new StopThread(threads).start();
    }
}