import java.util.Arrays;
import java.util.Comparator;

public class StopThread extends Thread {
    private final StartThread[] threads;

    public StopThread(StartThread[] threads) {
        this.threads = Arrays.stream(threads)
                .sorted(Comparator.comparingInt(StartThread::getMillis))
                .toArray(StartThread[]::new);
    }

    @Override
    public void run() {
        for (int i = 0; i < threads.length; i++) {
            try {
                int sleepTime;

                if (i == 0) {
                    sleepTime = threads[i].getMillis();
                } else {
                    sleepTime = threads[i].getMillis() - threads[i - 1].getMillis();
                }

                Thread.sleep(sleepTime);

                threads[i].running = false;
                System.out.println("Stopped thread " + threads[i].getID());
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }
}