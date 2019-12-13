
from pyOpenBCI import OpenBCICyton
from pylsl import StreamInlet, resolve_stream
from collections import deque
import numpy as np
import time
from matplotlib import style
import matplotlib.pyplot as plt

last_print = time.time()
fps_counter = deque(maxlen=150)


# Resolve an EEG stream on the LSL network
print('looking for an EEG stream...')
streams = resolve_stream('type','EEG')
# Creates a new inlet to read from the stream
inlet = StreamInlet(streams[0])
channel_data = {}

for i in range(5): # how many iterations. Change to a while True

    for i in range(16): #number of channels
        sample, timestamp = inlet.pull_sample()
        if i not in channel_data:
            channel_data[i] = sample
        else:
            channel_data[i].append(sample)

    fps_counter.append(time.time() - last_print)
    last_print = time.time()
    cur_raw_hz = 1/(sum(fps_counter)/len(fps_counter))
    print(cur_raw_hz)


# Not working for more than one sample
for chan in channel_data:
    print(channel_data[chan])
    plt.plot(channel_data[chan])
plt.show()

# OPENBCI EXAMPLE 2

# SCALE_FACTOR_EEG = (4500000)/24/(2**23-1) #uV/count
# SCALE_FACTOR_AUX = 0.002 / (2**4)
#
#
# print("Creating LSL stream for EEG. \nName: OpenBCIEEG\nID: OpenBCItestEEG\n")
#
# info_eeg = StreamInfo('OpenBCIEEG', 'EEG', 16, 250, 'float32', 'obci_eeg3')
#
# print("Creating LSL stream for AUX. \nName: OpenBCIAUX\nID: OpenBCItestEEG\n")
#
# info_aux = StreamInfo('OpenBCIAUX', 'AUX', 3, 250, 'float32', 'OpenBCItestAUX')
#
# outlet_eeg = StreamOutlet(info_eeg)
# outlet_aux = StreamOutlet(info_aux)
#
# def lsl_streamers(sample):
#     outlet_eeg.push_sample(np.array(sample.channels_data)*SCALE_FACTOR_EEG)
#     outlet_aux.push_sample(np.array(sample.aux_data)*SCALE_FACTOR_AUX)
#     print(np.array(sample.channels_data)*SCALE_FACTOR_EEG);
#     #print(outlet_aux.push_sample(np.array(sample.aux_data)*SCALE_FACTOR_AUX))
#
# board = OpenBCICyton(port='COM4', daisy=True);
#
# board.start_stream(lsl_streamers)




## GENERAL OPENBCI PYTHON NOTES

# OUR BOARD
    # board = OpenBCICyton(port='COM4', daisy=True);

# GENERIC COMMAND to write commands to boards
    # board.write_command(command);

# STREAM
    # board.start_stream(callback);

# Stream attributes:
# packet_id = The ID of the incoming packet
# channels_data = The raw EEG data of each channel (in counts, so this MUST be scaled)
# aux_data = Accelerometer data (raw, so MUST be scaled)

# SCALING FACTORS
    # uVolts_per_count = (4500000/24/(2**23-1)) # uV/count
    # accel_G_per_count = (0.002/(2**4)) # G/count
