package hr.algebra.controller;

import hr.algebra.viewmodel.PersonViewModel;
import java.net.URL;
import java.util.Map;
import java.util.ResourceBundle;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.Tab;
import javafx.scene.control.TabPane;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.TextField;
import javafx.scene.image.ImageView;

public class PeopleController implements Initializable {
    
    private Map<TextField, Label> validationMap;
    private PersonViewModel selectedPersonViewModel;
    private Tab previousTab;
    private final ObservableList<PersonViewModel> people = FXCollections.observableArrayList();

    @FXML
    private TabPane tpContent;
    @FXML
    private Tab tabListPeople;
    @FXML
    private TableView<PersonViewModel> tvPeople;
    @FXML
    private TableColumn<PersonViewModel, String> tcFirstName, tcLastName, tcEmail;
    @FXML
    private TableColumn<PersonViewModel, Integer> tcAge;
    @FXML
    private Button btnEdit;
    @FXML
    private Button btnDelete;
    @FXML
    private Tab tabEditPerson;
    @FXML
    private ImageView ivPerson;
    @FXML
    private Button btnUpload;
    @FXML
    private Button btnCommit;
    @FXML
    private TextField tfFirstName;
    @FXML
    private Label lbFirstNameError;
    @FXML
    private Label lbPictureError;
    @FXML
    private TextField tfLastName;
    @FXML
    private Label lbLastNameError;
    @FXML
    private TextField tfAge;
    @FXML
    private Label lbAgeError;
    @FXML
    private TextField tfEmail;
    @FXML
    private Label lbEmailError;

    @Override
    public void initialize(URL url, ResourceBundle rb) {
        
    }

    @FXML
    private void edit(ActionEvent event) {
    }

    @FXML
    private void delete(ActionEvent event) {
    }

    @FXML
    private void uploadImage(ActionEvent event) {
    }

    @FXML
    private void commit(ActionEvent event) {
    }
}
