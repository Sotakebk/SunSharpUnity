using System;
using SunSharp.Native;
using UnityEngine;

namespace SunSharp.Unity
{
    internal class SunVoxLibCWithTrackedState : ISunVoxLibC
    {
        private readonly object _lock = new object();
        private bool _initialized;

        internal bool IsInitialized
        {
            get
            {
                lock (_lock)
                {
                    return _initialized;
                }
            }
        }

        internal void MaybeDeinitialize()
        {
            lock (_lock)
            {
                if (!_initialized)
                {
                    return;
                }
                try
                {
                    var res = (this as ISunVoxLibC).sv_deinit();
                    if (res == 0)
                    {
                        _initialized = false;
                    }
                    else
                    {
                        Debug.LogError($"Failed to deinitialize the SunVox engine on library deinitialization. sv_deinit returned {res}.");
                    }
                }
                catch (Exception ex)
                {
                    Debug.LogException(ex);
                    Debug.LogError("Failed to deinitialize the SunVox engine.");
                    throw;
                }
            }
        }

        int ISunVoxLibC.sv_init(IntPtr config, int freq, int channels, uint flags)
        {
            lock (_lock)
            {
                if (_initialized)
                {
                    throw new Exception("The SunVox engine is already initialized. You cannot initialize it twice without deinitializing it first.");
                }

                try
                {
                    var ret = DllImport.sv_init(config, freq, channels, flags);
                    if (ret > 0)
                    {
                        _initialized = true;
                    }
                    return ret;
                }
                catch (Exception ex)
                {
                    Debug.LogException(ex);
                    Debug.LogError("Failed to initialize the SunVox engine.");
                    throw;
                }
            }
        }

        int ISunVoxLibC.sv_deinit()
        {
            lock (_lock)
            {
                if (!_initialized)
                {
                    throw new Exception("The SunVox engine is not initialized. You cannot deinitialize it without initializing it first.");
                }

                try
                {
                    var ret = DllImport.sv_deinit();
                    if (_initialized && ret == 0)
                    {
                        _initialized = false;
                    }
                    return ret;
                }
                catch (Exception ex)
                {
                    Debug.LogException(ex);
                    Debug.LogError("Failed to deinitialize the SunVox engine.");
                    throw;
                }
            }
        }

        int ISunVoxLibC.sv_audio_callback(IntPtr buf, int frames, int latency, uint out_time) => DllImport.sv_audio_callback(buf, frames, latency, out_time);

        int ISunVoxLibC.sv_audio_callback2(IntPtr buf, int frames, int latency, uint out_time, int in_type, int in_channels, IntPtr in_buf) => DllImport.sv_audio_callback2(buf, frames, latency, out_time, in_type, in_channels, in_buf);

        int ISunVoxLibC.sv_close_slot(int slot) => DllImport.sv_close_slot(slot);

        int ISunVoxLibC.sv_connect_module(int slot, int source, int destination) => DllImport.sv_connect_module(slot, source, destination);

        int ISunVoxLibC.sv_disconnect_module(int slot, int source, int destination) => DllImport.sv_disconnect_module(slot, source, destination);

        int ISunVoxLibC.sv_end_of_song(int slot) => DllImport.sv_end_of_song(slot);

        int ISunVoxLibC.sv_find_module(int slot, IntPtr name) => DllImport.sv_find_module(slot, name);

        int ISunVoxLibC.sv_find_pattern(int slot, IntPtr name) => DllImport.sv_find_pattern(slot, name);

        int ISunVoxLibC.sv_get_autostop(int slot) => DllImport.sv_get_autostop(slot);

        int ISunVoxLibC.sv_get_current_line(int slot) => DllImport.sv_get_current_line(slot);

        int ISunVoxLibC.sv_get_current_line2(int slot) => DllImport.sv_get_current_line2(slot);

        int ISunVoxLibC.sv_get_current_signal_level(int slot, int channel) => DllImport.sv_get_current_signal_level(slot, channel);

        int ISunVoxLibC.sv_get_module_color(int slot, int mod_num) => DllImport.sv_get_module_color(slot, mod_num);

        int ISunVoxLibC.sv_get_module_ctl_group(int slot, int mod_num, int ctl_num) => DllImport.sv_get_module_ctl_group(slot, mod_num, ctl_num);

        int ISunVoxLibC.sv_get_module_ctl_max(int slot, int mod_num, int ctl_num, int scaled) => DllImport.sv_get_module_ctl_max(slot, mod_num, ctl_num, scaled);

        int ISunVoxLibC.sv_get_module_ctl_min(int slot, int mod_num, int ctl_num, int scaled) => DllImport.sv_get_module_ctl_min(slot, mod_num, ctl_num, scaled);

        int ISunVoxLibC.sv_get_module_ctl_offset(int slot, int mod_num, int ctl_num) => DllImport.sv_get_module_ctl_offset(slot, mod_num, ctl_num);

        int ISunVoxLibC.sv_get_module_ctl_type(int slot, int mod_num, int ctl_num) => DllImport.sv_get_module_ctl_type(slot, mod_num, ctl_num);

        int ISunVoxLibC.sv_get_module_ctl_value(int slot, int mod_num, int ctl_num, int scaled) => DllImport.sv_get_module_ctl_value(slot, mod_num, ctl_num, scaled);

        int ISunVoxLibC.sv_get_number_of_module_ctls(int slot, int mod_num) => DllImport.sv_get_number_of_module_ctls(slot, mod_num);

        int ISunVoxLibC.sv_get_number_of_modules(int slot) => DllImport.sv_get_number_of_modules(slot);

        int ISunVoxLibC.sv_get_number_of_patterns(int slot) => DllImport.sv_get_number_of_patterns(slot);

        int ISunVoxLibC.sv_get_pattern_event(int slot, int pat_num, int track, int line, int column) => DllImport.sv_get_pattern_event(slot, pat_num, track, line, column);

        int ISunVoxLibC.sv_get_pattern_lines(int slot, int pat_num) => DllImport.sv_get_pattern_lines(slot, pat_num);

        int ISunVoxLibC.sv_get_pattern_tracks(int slot, int pat_num) => DllImport.sv_get_pattern_tracks(slot, pat_num);

        int ISunVoxLibC.sv_get_pattern_x(int slot, int pat_num) => DllImport.sv_get_pattern_x(slot, pat_num);

        int ISunVoxLibC.sv_get_pattern_y(int slot, int pat_num) => DllImport.sv_get_pattern_y(slot, pat_num);

        int ISunVoxLibC.sv_get_sample_rate() => DllImport.sv_get_sample_rate();

        int ISunVoxLibC.sv_get_song_bpm(int slot) => DllImport.sv_get_song_bpm(slot);

        int ISunVoxLibC.sv_get_song_tpl(int slot) => DllImport.sv_get_song_tpl(slot);

        int ISunVoxLibC.sv_get_time_map(int slot, int start_line, int len, IntPtr dest, int flags) => DllImport.sv_get_time_map(slot, start_line, len, dest, flags);

        int ISunVoxLibC.sv_load(int slot, IntPtr name) => DllImport.sv_load(slot, name);

        int ISunVoxLibC.sv_load_from_memory(int slot, IntPtr data, uint data_size) => DllImport.sv_load_from_memory(slot, data, data_size);

        int ISunVoxLibC.sv_load_module(int slot, IntPtr file_name, int x, int y, int z) => DllImport.sv_load_module(slot, file_name, x, y, z);

        int ISunVoxLibC.sv_load_module_from_memory(int slot, IntPtr data, uint data_size, int x, int y, int z) => DllImport.sv_load_module_from_memory(slot, data, data_size, x, y, z);

        int ISunVoxLibC.sv_lock_slot(int slot) => DllImport.sv_lock_slot(slot);

        int ISunVoxLibC.sv_metamodule_load(int slot, int mod_num, IntPtr file_name) => DllImport.sv_metamodule_load(slot, mod_num, file_name);

        int ISunVoxLibC.sv_metamodule_load_from_memory(int slot, int mod_num, IntPtr data, uint data_size) => DllImport.sv_metamodule_load_from_memory(slot, mod_num, data, data_size);

        int ISunVoxLibC.sv_module_curve(int slot, int mod_num, int curve_num, IntPtr data, int len, int w) => DllImport.sv_module_curve(slot, mod_num, curve_num, data, len, w);

        int ISunVoxLibC.sv_new_module(int slot, IntPtr type, IntPtr name, int x, int y, int z) => DllImport.sv_new_module(slot, type, name, x, y, z);

        int ISunVoxLibC.sv_new_pattern(int slot, int clone, int x, int y, int tracks, int lines, int icon_seed, IntPtr name) => DllImport.sv_new_pattern(slot, clone, x, y, tracks, lines, icon_seed, name);

        int ISunVoxLibC.sv_open_slot(int slot) => DllImport.sv_open_slot(slot);

        int ISunVoxLibC.sv_pattern_mute(int slot, int pat_num, int mute) => DllImport.sv_pattern_mute(slot, pat_num, mute);

        int ISunVoxLibC.sv_pause(int slot) => DllImport.sv_pause(slot);

        int ISunVoxLibC.sv_play(int slot) => DllImport.sv_play(slot);

        int ISunVoxLibC.sv_play_from_beginning(int slot) => DllImport.sv_play_from_beginning(slot);

        int ISunVoxLibC.sv_remove_module(int slot, int mod_num) => DllImport.sv_remove_module(slot, mod_num);

        int ISunVoxLibC.sv_remove_pattern(int slot, int pat_num) => DllImport.sv_remove_pattern(slot, pat_num);

        int ISunVoxLibC.sv_resume(int slot) => DllImport.sv_resume(slot);

        int ISunVoxLibC.sv_rewind(int slot, int line_num) => DllImport.sv_rewind(slot, line_num);

        int ISunVoxLibC.sv_sampler_load(int slot, int sampler_module, IntPtr file_name, int sample_slot) => DllImport.sv_sampler_load(slot, sampler_module, file_name, sample_slot);

        int ISunVoxLibC.sv_sampler_load_from_memory(int slot, int sampler_module, IntPtr data, uint data_size, int sample_slot) => DllImport.sv_sampler_load_from_memory(slot, sampler_module, data, data_size, sample_slot);

        int ISunVoxLibC.sv_save(int slot, IntPtr name) => DllImport.sv_save(slot, name);

        int ISunVoxLibC.sv_send_event(int slot, int track_num, int note, int vel, int module, int ctl, int ctl_val) => DllImport.sv_send_event(slot, track_num, note, vel, module, ctl, ctl_val);

        int ISunVoxLibC.sv_set_autostop(int slot, int autostop) => DllImport.sv_set_autostop(slot, autostop);

        int ISunVoxLibC.sv_set_event_t(int slot, int set, int t) => DllImport.sv_set_event_t(slot, set, t);

        int ISunVoxLibC.sv_set_module_color(int slot, int mod_num, int color) => DllImport.sv_set_module_color(slot, mod_num, color);

        int ISunVoxLibC.sv_set_module_ctl_value(int slot, int mod_num, int ctl_num, int val, int scaled) => DllImport.sv_set_module_ctl_value(slot, mod_num, ctl_num, val, scaled);

        int ISunVoxLibC.sv_set_module_finetune(int slot, int mod_num, int finetune) => DllImport.sv_set_module_finetune(slot, mod_num, finetune);

        int ISunVoxLibC.sv_set_module_name(int slot, int mod_num, IntPtr name) => DllImport.sv_set_module_name(slot, mod_num, name);

        int ISunVoxLibC.sv_set_module_relnote(int slot, int mod_num, int relative_note) => DllImport.sv_set_module_relnote(slot, mod_num, relative_note);

        int ISunVoxLibC.sv_set_module_xy(int slot, int mod_num, int x, int y) => DllImport.sv_set_module_xy(slot, mod_num, x, y);

        int ISunVoxLibC.sv_set_pattern_event(int slot, int pat_num, int track, int line, int nn, int vv, int mm, int ccee, int xxyy) => DllImport.sv_set_pattern_event(slot, pat_num, track, line, nn, vv, mm, ccee, xxyy);

        int ISunVoxLibC.sv_set_pattern_name(int slot, int pat_num, IntPtr name) => DllImport.sv_set_pattern_name(slot, pat_num, name);

        int ISunVoxLibC.sv_set_pattern_size(int slot, int pat_num, int tracks, int lines) => DllImport.sv_set_pattern_size(slot, pat_num, tracks, lines);

        int ISunVoxLibC.sv_set_pattern_xy(int slot, int pat_num, int x, int y) => DllImport.sv_set_pattern_xy(slot, pat_num, x, y);

        int ISunVoxLibC.sv_set_song_name(int slot, IntPtr name) => DllImport.sv_set_song_name(slot, name);

        int ISunVoxLibC.sv_stop(int slot) => DllImport.sv_stop(slot);

        int ISunVoxLibC.sv_sync_resume(int slot) => DllImport.sv_sync_resume(slot);

        int ISunVoxLibC.sv_unlock_slot(int slot) => DllImport.sv_unlock_slot(slot);

        int ISunVoxLibC.sv_update_input() => DllImport.sv_update_input();

        int ISunVoxLibC.sv_volume(int slot, int vol) => DllImport.sv_volume(slot, vol);

        int ISunVoxLibC.sv_vplayer_load(int slot, int mod_num, IntPtr file_name) => DllImport.sv_vplayer_load(slot, mod_num, file_name);

        int ISunVoxLibC.sv_vplayer_load_from_memory(int slot, int mod_num, IntPtr data, uint data_size) => DllImport.sv_vplayer_load_from_memory(slot, mod_num, data, data_size);

        IntPtr ISunVoxLibC.sv_get_log(int size) => DllImport.sv_get_log(size);

        IntPtr ISunVoxLibC.sv_get_module_ctl_name(int slot, int mod_num, int ctl_num) => DllImport.sv_get_module_ctl_name(slot, mod_num, ctl_num);

        IntPtr ISunVoxLibC.sv_get_module_inputs(int slot, int mod_num) => DllImport.sv_get_module_inputs(slot, mod_num);

        IntPtr ISunVoxLibC.sv_get_module_name(int slot, int mod_num) => DllImport.sv_get_module_name(slot, mod_num);

        IntPtr ISunVoxLibC.sv_get_module_outputs(int slot, int mod_num) => DllImport.sv_get_module_outputs(slot, mod_num);

        IntPtr ISunVoxLibC.sv_get_module_type(int slot, int mod_num) => DllImport.sv_get_module_type(slot, mod_num);

        IntPtr ISunVoxLibC.sv_get_pattern_data(int slot, int pat_num) => DllImport.sv_get_pattern_data(slot, pat_num);

        IntPtr ISunVoxLibC.sv_get_pattern_name(int slot, int pat_num) => DllImport.sv_get_pattern_name(slot, pat_num);

        IntPtr ISunVoxLibC.sv_get_song_name(int slot) => DllImport.sv_get_song_name(slot);

        uint ISunVoxLibC.sv_get_module_finetune(int slot, int mod_num) => DllImport.sv_get_module_finetune(slot, mod_num);

        uint ISunVoxLibC.sv_get_module_flags(int slot, int mod_num) => DllImport.sv_get_module_flags(slot, mod_num);

        uint ISunVoxLibC.sv_get_module_scope2(int slot, int mod_num, int channel, IntPtr dest_buf, uint samples_to_read) => DllImport.sv_get_module_scope2(slot, mod_num, channel, dest_buf, samples_to_read);

        uint ISunVoxLibC.sv_get_module_xy(int slot, int mod_num) => DllImport.sv_get_module_xy(slot, mod_num);

        uint ISunVoxLibC.sv_get_song_length_frames(int slot) => DllImport.sv_get_song_length_frames(slot);

        uint ISunVoxLibC.sv_get_song_length_lines(int slot) => DllImport.sv_get_song_length_lines(slot);

        uint ISunVoxLibC.sv_get_ticks() => DllImport.sv_get_ticks();

        uint ISunVoxLibC.sv_get_ticks_per_second() => DllImport.sv_get_ticks_per_second();

        public IntPtr sv_save_to_memory(int slot, IntPtr size) => DllImport.sv_save_to_memory(slot, size);

        public int sv_get_base_version(int slot) => DllImport.sv_get_base_version(slot);

        public int sv_sampler_par(int slot, int mod_num, int sample_slot, int par, int par_val, int set) => DllImport.sv_sampler_par(slot, mod_num, sample_slot, par, par_val, set);
    }
}
