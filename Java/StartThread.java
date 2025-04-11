public class StartThread extends Thread {
    public volatile boolean running = true;
    private final int id;
    private final int step;
    private final int millis;

    public StartThread(int id, int step, int millis) {
        this.id = id;
        this.step = step;
        this.millis = millis;
    }

    public int getID() {
        return id;
    }

    public int getMillis() {
        return millis;
    }

    @Override
    public void run() {
        int sum = 0;
        int count = 0;

        while (running) {
            sum += step;
            count++;
        }

        System.out.println("ID Thread " + id + ": sum = " + sum + ", count = " + count);
    }
}
