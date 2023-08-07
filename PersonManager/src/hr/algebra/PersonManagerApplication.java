package hr.algebra;

import hr.algebra.dao.RepositoryFactory;
import java.io.IOException;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;

public class PersonManagerApplication extends Application {
    
    @Override
    public void start(Stage primaryStage) throws IOException {
        Parent root = FXMLLoader.load(getClass().getResource("view/People.fxml"));
        
        Scene scene = new Scene(root, 600, 400);
        
        primaryStage.setTitle("Person manager");
        primaryStage.setScene(scene);
        primaryStage.show();
    }

    @Override
    public void stop() throws Exception {
        super.stop();
        RepositoryFactory.getRepository().release();
    }
    
    public static void main(String[] args) {
        launch(args);
    }
}
