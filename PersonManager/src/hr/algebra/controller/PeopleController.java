package hr.algebra.controller;

import com.sun.imageio.plugins.common.ImageUtil;
import hr.algebra.dao.RepositoryFactory;
import hr.algebra.utility.FileUtils;
import hr.algebra.utility.ImageUtils;
import hr.algebra.utility.ValidationUtils;
import hr.algebra.viewmodel.JobViewModel;
import hr.algebra.viewmodel.PersonViewModel;
import java.io.ByteArrayInputStream;
import java.io.File;
import java.io.IOException;
import java.net.URL;
import java.util.AbstractMap;
import java.util.Map;
import java.util.ResourceBundle;
import java.util.concurrent.atomic.AtomicBoolean;
import java.util.function.UnaryOperator;
import java.util.logging.Level;
import java.util.logging.Logger;
import java.util.stream.Collectors;
import java.util.stream.Stream;
import javafx.collections.FXCollections;
import javafx.collections.ListChangeListener;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Alert;
import javafx.scene.control.Button;
import javafx.scene.control.ComboBox;
import javafx.scene.control.Label;
import javafx.scene.control.Tab;
import javafx.scene.control.TabPane;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.TextField;
import javafx.scene.control.TextFormatter;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.util.converter.IntegerStringConverter;

public class PeopleController implements Initializable {
    
    private Map<TextField, Label> validationMap;
    private PersonViewModel selectedPersonViewModel;
    private JobViewModel selectedJobViewModel;
    private Tab previousTab;
    private final ObservableList<PersonViewModel> people = FXCollections.observableArrayList();
    private final ObservableList<JobViewModel> jobs = FXCollections.observableArrayList();

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
    
    @FXML
    private Tab tabListJobs;
    @FXML
    private TableView<JobViewModel> tvJobs;
    @FXML
    private TableColumn<JobViewModel,  Integer> tcID;
    @FXML
    private TableColumn<JobViewModel, String> tcName;
    @FXML
    private Tab tabAddJob;
    @FXML
    private TextField tfJobName;
    @FXML
    private Label lbJobNameError;
    @FXML
    private ComboBox cbJobs;
    @FXML
    private TableColumn<PersonViewModel, Integer> tcJobID;

    @Override
    public void initialize(URL url, ResourceBundle rb) {
        initializeValidation();
        initializePeople();
        initializeTable();
        initializeJobs();
        initializeJobTable();
        addIntegerMask(tfAge);
        setupListeners();
    }

    @FXML
    private void edit(ActionEvent  event) {
        if (tvPeople.getSelectionModel().getSelectedItem() != null) {
            bindPerson(tvPeople.getSelectionModel().getSelectedItem());
            tpContent.getSelectionModel().select(tabEditPerson);
            previousTab = tabEditPerson;
        }
    }

    @FXML
    private void delete(ActionEvent event) {
        if (tvPeople.getSelectionModel().getSelectedItem() != null) {
            people.remove(tvPeople.getSelectionModel().getSelectedItem());
        }
    }

    @FXML
    private void uploadImage(ActionEvent event) {
        File file = FileUtils.uploadFileDialog(tfFirstName.getScene().getWindow(), "jpg", "jpeg", "png");
        if (file != null) {
            Image image = new Image(file.toURI().toString());
            ivPerson.setImage(image);
            String extension = file.getName().substring(file.getName().lastIndexOf(".") + 1);
            try {
                selectedPersonViewModel.getPerson().setPicture(ImageUtils.imageToByteArray(image, extension));
            } catch (IOException ex) {
                Logger.getLogger(PeopleController.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
    }

    @FXML
    private void commit(ActionEvent event) {
        if (formValid()) {
            JobViewModel jobViewModel = (JobViewModel)cbJobs.getValue();
            
            selectedPersonViewModel.getPerson().setFirstName(tfFirstName.getText());
            selectedPersonViewModel.getPerson().setLastName(tfLastName.getText());
            selectedPersonViewModel.getPerson().setAge(Integer.valueOf(tfAge.getText()));
            selectedPersonViewModel.getPerson().setEmail(tfEmail.getText());
            selectedPersonViewModel.getPerson().setJobID(jobViewModel.getIdJobProperty().get());
            
            if (selectedPersonViewModel.getPerson().getIDPerson() == 0) {
                people.add(selectedPersonViewModel);
            }
            else {
                try {
                    RepositoryFactory.getRepository().updatePerson(selectedPersonViewModel.getPerson());
                    tvPeople.refresh();
                } catch (Exception ex) {
                    Logger.getLogger(PeopleController.class.getName()).log(Level.SEVERE, null, ex);
                }
            }
            
            selectedPersonViewModel = null;
            tpContent.getSelectionModel().select(tabListPeople);
            resetForm();
        }
    }
    
    @FXML
    public void addJob(ActionEvent event) {
        if (jobFormValid()) {
            selectedJobViewModel.getJob().setName(tfJobName.getText().trim());
            
            if (selectedJobViewModel.getJob().getIDJob()== 0) {
                jobs.add(selectedJobViewModel);
            }
            else {
                try {
                    RepositoryFactory.getRepository().updateJob(selectedJobViewModel.getJob());
                    tvJobs.refresh();
                } catch (Exception ex) {
                    Logger.getLogger(PeopleController.class.getName()).log(Level.SEVERE, null, ex);
                }
            }
            
            selectedJobViewModel = null;
            tpContent.getSelectionModel().select(tabListJobs);
            resetForm();
        }
    }

    @FXML
    public void deleteJob(ActionEvent event) {
        if (tvJobs.getSelectionModel().getSelectedItem() != null) {
            for (PersonViewModel personViewModel : people) {
                   if (personViewModel.getJobProperty().get() == tvJobs.getSelectionModel().getSelectedItem().getIdJobProperty().get()) {
                       Alert alert = new Alert(Alert.AlertType.INFORMATION);
                       alert.setTitle("Error!");
                       alert.setHeaderText("No can do");
                       alert.setContentText("Subject in use! First delete the person who is using it!");
                       alert.showAndWait();
                       return;
                   }
               }
            jobs.remove(tvJobs.getSelectionModel().getSelectedItem());
        }
    }
    
    @FXML
    public void editJob(ActionEvent event) {
        if (tvJobs.getSelectionModel().getSelectedItem() != null) {
            bindJob(tvJobs.getSelectionModel().getSelectedItem());
            tpContent.getSelectionModel().select(tabAddJob);
            previousTab = tabAddJob;
        }
    }
    
    public boolean jobFormValid() {
        final AtomicBoolean ok = new AtomicBoolean(true);
        
        if (tfJobName.getText().trim().isEmpty()) {
            lbJobNameError.setVisible(true);
            ok.set(false);
        }
        
        return ok.get();
    }
    
    private void initializeValidation() {
        validationMap = Stream.of(
                new AbstractMap.SimpleImmutableEntry<>(tfFirstName, lbFirstNameError),
                new AbstractMap.SimpleImmutableEntry<>(tfLastName, lbLastNameError),
                new AbstractMap.SimpleImmutableEntry<>(tfAge, lbAgeError),
                new AbstractMap.SimpleImmutableEntry<>(tfEmail, lbEmailError))
                    .collect(
                        Collectors.toMap(Map.Entry::getKey, Map.Entry::getValue));
    }

    private void initializePeople() {
        try {
            RepositoryFactory.getRepository().getPeople().forEach(p -> people.add(new PersonViewModel(p)));
        } catch (Exception ex) {
            Logger.getLogger(PeopleController.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    private void initializeTable() {
        tcFirstName.setCellValueFactory(p -> p.getValue().getFirstNameProperty());
        tcLastName.setCellValueFactory(p -> p.getValue().getLastNameProperty());
        tcAge.setCellValueFactory(p -> p.getValue().getAgeProperty().asObject());
        tcEmail.setCellValueFactory(p -> p.getValue().getEmailProperty());
        tcJobID.setCellValueFactory(p -> p.getValue().getJobProperty().asObject());
        tvPeople.setItems(people);
        cbJobs.setItems(jobs);
        cbJobs.getSelectionModel().selectFirst();
    }

    private void initializeJobs() {
        try {
            RepositoryFactory.getRepository().getJobs().forEach(job -> jobs.add(new JobViewModel(job)));
        } catch (Exception ex) {
            Logger.getLogger(PeopleController.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    private void initializeJobTable() {
        tcName.setCellValueFactory(subject -> subject.getValue().getNameProperty());
        tcID.setCellValueFactory(subject -> subject.getValue().getIdJobProperty().asObject());
        tvJobs.setItems(jobs);
    }
    
    private void addIntegerMask(TextField textField) {
        UnaryOperator<TextFormatter.Change> filter = change -> {
            if (change.getText().matches("\\d*")) {
                return change;
            }
            
            return null;
        };
        
        textField.setTextFormatter(new TextFormatter<>(new IntegerStringConverter(), 0, filter));
    }

    private void setupListeners() {
        tpContent.setOnMouseClicked(event -> {
            if (tpContent.getSelectionModel().getSelectedItem().equals(tabEditPerson) && !tabEditPerson.equals(previousTab)) {
                bindPerson(null);
            }
            
            if(tpContent.getSelectionModel().getSelectedItem().equals(tabAddJob) && !tabAddJob.equals(previousTab)){
                bindJob(null);
            }
            
            previousTab = tpContent.getSelectionModel().getSelectedItem();
        });
        
        people.addListener(new ListChangeListener<PersonViewModel> () {
            @Override
            public void onChanged(ListChangeListener.Change<? extends PersonViewModel> change) {
                if (change.next()) {
                    if (change.wasRemoved()) {
                        change.getRemoved().forEach(personViewModel -> {
                            try {
                                RepositoryFactory.getRepository().deletePerson(personViewModel.getPerson());
                            } catch (Exception ex) {
                                Logger.getLogger(PeopleController.class.getName()).log(Level.SEVERE, null, ex);
                            }
                        });
                    }
                    if (change.wasAdded()) {
                        change.getAddedSubList().forEach(personViewModel -> {
                            try {
                                int id = RepositoryFactory.getRepository().addPerson(personViewModel.getPerson());
                                personViewModel.getPerson().setIDPerson(id);
                            } catch (Exception ex) {
                                Logger.getLogger(PeopleController.class.getName()).log(Level.SEVERE, null, ex);
                            }
                        });
                    }
                }
            }
        });
        
        jobs.addListener((ListChangeListener.Change<? extends JobViewModel> change) -> {
            if (change.next()) {
                if (change.wasRemoved()) {
                    change.getRemoved().forEach(svm -> {
                        try {
                            RepositoryFactory.getRepository().deleteJob(svm.getJob());
                        } catch (Exception ex) {
                            Logger.getLogger(PeopleController.class.getName()).log(Level.SEVERE, null, ex);
                        }
                    });
                } else if (change.wasAdded()) {
                    change.getAddedSubList().forEach(svm -> {
                        try {
                            int idJob = RepositoryFactory.getRepository().addJob(svm.getJob());
                            svm.getJob().setIDJob(idJob);
                        } catch (Exception ex) {
                            Logger.getLogger(PeopleController.class.getName()).log(Level.SEVERE, null, ex);
                        }
                    });
                }
            }
        });
    }

    private void bindPerson(PersonViewModel personViewModel) {
        resetForm();
        
        selectedPersonViewModel = personViewModel != null ? personViewModel : new PersonViewModel(null);
        
        tfFirstName.setText(selectedPersonViewModel.getFirstNameProperty().get());
        tfLastName.setText(selectedPersonViewModel.getLastNameProperty().get());
        tfAge.setText(selectedPersonViewModel.getAgeProperty().get() + "");
        tfEmail.setText(selectedPersonViewModel.getEmailProperty().get());
        
        ivPerson.setImage(
                selectedPersonViewModel.getPictureProperty().get() != null
                    ? new Image(new ByteArrayInputStream(selectedPersonViewModel.getPictureProperty().get()))
                    : new Image(new File("src/assets/no_image.png").toURI().toString())
        );
    }
    
    public void bindJob(JobViewModel jobViewModel) {
        resetForm();
        selectedJobViewModel = jobViewModel != null ? jobViewModel : new JobViewModel(null);
        tfJobName.setText(selectedJobViewModel.getNameProperty().get());
    }

    private void resetForm() {
        validationMap.values().forEach(lb -> lb.setVisible(false));
        cbJobs.getSelectionModel().selectFirst();
        lbPictureError.setVisible(false);
    }

    private boolean formValid() {
        resetForm();
        
        final AtomicBoolean ok = new AtomicBoolean(true);
        
        validationMap.forEach((textField, label) -> {
            if (textField.getText().isEmpty() || textField.getId().contains("Email") && !ValidationUtils.isValidEmail(textField.getText())) {
                label.setVisible(true);
                ok.set(false);
            }
         });
        
        if (selectedPersonViewModel.getPictureProperty().get() == null) {
            lbPictureError.setVisible(true);
            ok.set(false);
        }
        
        return ok.get();
    }
}
