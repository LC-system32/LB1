public class StopThread extends Thread {
    private final StartThread[] threads;
    private final int[] millis;

    public StopThread(StartThread[] threads, int[] millis) {
        this.threads = threads;
        this.millis = millis;
    }

    @Override
    public void run() {
        for (int i = 0; i < threads.length; i++) {
            final int index = i;
            new Thread(() -> {
                try {
                    Thread.sleep(millis[index]);
                    threads[index].running = false;
                    System.out.println("Stopped thread " + threads[index].getID());
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }).start();
        }
    }
}