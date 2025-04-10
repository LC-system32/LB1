public class StartThread extends Thread {
    public volatile boolean running = true;
    private final int id;
    private final int step;

    public StartThread(int id, int step) {
        this.id = id;
        this.step = step;
    }

    public int getID() {
        return id;
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
