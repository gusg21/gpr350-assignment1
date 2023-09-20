# GPR350 Assignment 1

This assignment will involve setting up the basics of a physics engine. Primarily, that involves the Particle2D class and the
Integrator logic.

## Basic Instructions

1. Create your own **private** repository from this repo by hitting the "Use this template" button at the top of the page
2. Add me (@KevinRatelle) as a collaborator on your **private** repository.
3. Follow the directions in the assignment. This will involve filling in existing classes *and* creating new classes/files.
5. Test it on your local computer by following the build directions below
6. Add any files you modified or created under Assets/ to your git repository.
7. Push your code to GitHub (Don't push your binary files—the purpose of the prior step is to remove them). Every push will be automatically tested through a GitHub Action. You will know your code is correct when you see a green check mark next to the commit.*
8. Submit the URL to your private repository on Canvas. Submit even if you are not passing all tests so you can get partial credit.

* You are encouraged to also make commits much more frequently than this, earlier in development. Just don't be surprised when seeing an X on GitHub since not all of the tests will pass.

## Directory Structure and Files

- `/` Main directory including this `README.md`, the build scripts, and the test scripts.
- `/Assets` Main Unity files.
- `/ProjectSettings/...`* contains project settings for the Unity project. No need to modify this.
- `/Packages/...`* contains packeges for the Unity project. DO NOT add or remove packages!

### Specific Files

*indicates do not modify
&indicates you must modify


- `run_tests.sh`* script that kicks off Unity tests the result parser script.
- `test_cases.json`* test data. Used for grading.
- `test_runner.py`* script for parsing test data.
- `README.md`* this file
- `.gitignore`* files for git to ignore. Pre-configured to ignore unnecessary files.
- `LICENSE`* MIT License

- `Assets/...`
  
  - `Assets/Scripts/Particle2D.cs`& the particle class.
  - `Assets/Scripts/ParticleSpawner.cs`& the class that will handle logic for spawning particles.
  - `Assets/Scenes/TestScene.unity`& the scene that will be used to run tests. Your game objects should go here.
  
  - `Assets/Scripts/Integrator.cs`& *You need to create this!* Contains Integrator logic.

## Building and Running
The tests can be run directly from the Unity editor. In Unity, open the Test Runner window by selecting the menus
Window->General->Test Runner (see Fig. 1).

> [!NOTE]
> <figure>
>  <img width="460" alt="Fig.1 - Opening the Test Runner Window" src="https://github.com/CC-GPR-350/a1/assets/4325000/b9bed196-cf28-4f9c-80e0-00b51c2f82a9">
>  <figcaption>Fig.1 - Opening the Test Runner Window</figcaption>
> </figure>

Select "Play Mode" at the top of the newly opened Test Runner window. You should see
a series of tests (see Fig. 2). You can click "Run All" near the top of the window. All the tests will fail, but that's okay!
Each will give you an error message that describes the problem. If you get stuck, just focus on fixing each test, one at a time.
Once you have all the tests passing, you're done!

> [!NOTE]
> <figure>
>  <img width="502" alt="Fig.2 - Test Runner Window" src="https://github.com/CC-GPR-350/a1/assets/4325000/5fe553a2-da80-453d-8292-352588f206cf">
>  <figcaption>Fig.2 - Test Runner Window</figcaption>
> </figure>

## Viewing Your Projected Grade

You have two options for viewing your projected grade, based on the results of the automated testing. The easiest is to check
the Github Actions results, but you can also run the test runner locally.

### Viewing the Github Actions workflow results
You can run the Github Actions workflow by simply pushing your changes. You can view the results by clicking on the green check
(or red x, if you haven't fixed all the tests yet) visible on your repository. Then click "Details" on the popup that appears.
The "Parse Test Results" stage should automatically open. At the bottom of this stage will be a final score, and as you scroll
up you will be able to see a breakdown of which tests passed, failed, and how many points each test is worth. You can also see
any error messages and a stack trace for tests that failed.

### Running the test runner locally
*Running these scripts on Windows is completely untested, so you will be on your own for this!*
As such, I recommend checking your grade primarily through the Github Actions interface as detailed above.
Of course, you can always see what tests are failing or passing through the Unity editor, as detailed further above. Still, if you're curious about running the test runner locally, feel free to read on.

As a very broad overview, you will need to install Python 3.x and run the `run_tests.sh` file. `run_tests.sh` will need to be
modified to point to the correct location of Unity (see the [Unity CLI documentation](https://docs.unity3d.com/Manual/EditorCommandLineArguments.html) for details on how to do this). Also, since `run_tests.sh` is
written to be run in bash, the Linux command line shell, you will either need to attempt to run it from a bash equivalent
on Windows (such as `git bash` or `cygwin`) or run it from a Linux machine. The script is simple, so it may work through `cmd.exe`
without modification (besides correcting the `unity.exe` location).

## Checklist for Submission

- [ ] Did you add me (@KevinRatelle) as a collaborator on the repository?
- [ ] Did you replace every area that said "YOUR CODE HERE" with your code?
- [ ] Did you add all new files as required by the assignment?
- [ ] Did you ensure you are passing all of the unit tests? Do you see a green check mark on GitHub?
- [ ] Did you cite all sources, especially any place that you copied code from? Put code citations right next to where you inserted them.
- [ ] Did you add sufficient comments?
- [ ] Did you double check your code for good style?
- [ ] Did you try cleaning, building, and running once to make sure everything is in working order before submitting?
- [ ] Did you check the repository is free of temporary files such as the .vs/ and Temp/ and Library/ folders? Does your repository just contain Assets/, ProjectSettings/, Packages/, and the scripts that were originally included?
- [ ] Did you submit the URL to your repository on Canvas?
